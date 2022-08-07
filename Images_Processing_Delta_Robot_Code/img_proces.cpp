// The "Targets Detector" program.
//	g++ img_proces.cpp -o img_proces `pkg-config --cflags --libs opencv` -lwiringPi
//	./img_proces
#include "/home/pi/opencv-4.1.0/include/opencv4/opencv2/core/core.hpp"
#include "/home/pi/opencv-4.1.0/include/opencv4/opencv2/imgproc/imgproc.hpp"
#include "/home/pi/opencv-4.1.0/include/opencv4/opencv2/highgui/highgui.hpp"
#include "/home/pi/opencv-4.1.0/include/opencv4/opencv2/opencv.hpp" 
#include "/home/pi/opencv-4.1.0/include/opencv4/opencv2/core.hpp"
#include "/home/pi/opencv-4.1.0/include/opencv4/opencv2/highgui.hpp"
#include <stdlib.h>
#include <iostream>
#include <math.h>
#include <string.h>
#include <string>
#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <wiringPi.h>
#include "/home/pi/Desktop/WiringPi-master/wiringPi/wiringSerial.h"
#include "v_planner.h"
Velocity_Planner_Class V_planner;

using namespace cv;
using namespace std;

const char* wndname = "Targets Detection";
const int begin_col = 130, end_col = 490;
const int velocity_loader = 40;
int velocity_loader_img = (int) velocity_loader * 1.8;

enum COLOR{YELLOW = 0, BLUE = 1, PINK = 2};
bool isBusy;
int fd;

vector<string> Gcode_queue;
vector<Targets> targets_to_execute;

struct Targets 
{
	vector<Point> contour;
	float area;
	COLOR color;
	Point center;
	unsigned int time;
	int ID;
	int new_y;
};

struct Position 
{
    int X, Y, Z;
	
    Position() 
	{
        X = 0;
		Y = 0;
		Z = 0;
    }
	
    Position(float x, float y, float z) {
        X = x;
		Y = y;
		Z = z;
    }
};
	Position contact_position;
	Position up_contact_position;
	Position current_position;
	Position pink_box = Position(-120, -160, -410);
	Position blue_box = Position(-120, -100, -410);
	Position yellow_box = Position(-120, -40, -410);
	Position ready_position = Position(0, 0, -360);
	
float to_real_dimention(int type, float coor_value);
	
string Gcode_to_Position(Position _position);

Point find_center_point(vector<Point> array);

static double angle( Point pt1, Point pt2, Point pt0 );

static void findSquares( unsigned int time, Mat& frame,  vector<Targets>& targets);

static void drawSquares( Mat& image, vector<Targets>& targets);

void sortSquares( vector<Targets>& targets, vector<Targets>& sorted_targets );

void compareTargets(unsigned int time, vector<Targets>& sorted_targets, vector<Targets>& estimate_targets);

void Gcode_send(string Gcode);

string read_serial();

void get_value(int* position, string s);

float TravelTime(Position CurrentPoint, Position DesiredPoint);

bool Gcode_generate(unsigned int time_cap, Targets target);

int main(int /*argc*/, char** /*argv*/)
{
    VideoCapture cap(0); 
	if (!cap.isOpened())
	{
		cout << "Open the Video camera!"; 
		return -1;
	}
    Mat cap_result;
    namedWindow( wndname, 1 );
	unsigned int time_cap = 0;
	unsigned int time_loader_running = 0;
    vector<Targets> targets;	
	vector<Targets> sorted_targets;
	vector<Targets> estimate_targets;
	
	//OPEN SERIAL_PORT
	if((fd = serialOpen ("/dev/ttyUSB0", 115200)) < 0 )
	{
		fprintf (stderr, "Unable to open serial device: %s\n", strerror (errno));
	}
	
	// PREPARE
	cout<<"Init...\n"<<endl;
	Gcode_send("M207 P90");//BES - begin_end_speed
	Gcode_send("M203 S250");//SPEED
	Gcode_send("M204 A100");//ACCEL
	Gcode_send("G28");//HOMING
	Gcode_send(Gcode_to_Position(ready_position));//TO READY POSITION
	string v_loader = "M370 K" + to_string(velocity_loader);
	Gcode_send(v_loader);//LOADER RUN
	Gcode_send("M11");
	
	isBusy = true;
	while (isBusy == true)
	{
		if (read_serial() == ":Done")
		{
			isBusy = false;
			cout<<"setup_successful!\n"<<endl;
		}
	}

	while (1)
	{
		time_loader_running = millis() - time_cap;
		time_cap = millis();

		//receive
		string c = read_serial();
		if (c == ":Done")
		{
			isBusy = false;
			cout<<"isBusy = false"<<endl;
			
			Gcode_send(":Position");
			c = read_serial();
			if (c[1] == 'P')//update current_position
			{
				int _position[3];
				get_value(_position, c);
				current_position.X = _position[0];
				current_position.Y = _position[1];
				current_position.Z = _position[2];
			cout<<"update current_position!\n"<<endl;
			}
		}
		//send
		if (Gcode_queue.size() >0)
		{
			Gcode_send(Gcode_queue[0]);
			Gcode_queue.erase(Gcode_queue.begin());
		}
		else
		{
			if (targets_to_execute.size() > 0 && isBusy == false)
			{
				cout<<'\n'<<"targets_to_execute!"<<endl;
				if (Gcode_generate(time_cap, targets_to_execute[0]))
				{
					isBusy = true;
				}
				targets_to_execute.erase(targets_to_execute.begin());
				cout<<"targets_to_execute.size() = "<<targets_to_execute.size()<<endl;
			}
			else if (isBusy == false)
			{
				if(current_position.X != ready_position.X && current_position.Y != ready_position.Y && current_position.Z != ready_position.Z)
				{	cout<< "go to ready_position!\n"<<endl;
					current_position = ready_position;
					Gcode_send(Gcode_to_Position(ready_position));
					Gcode_send("M11");
					isBusy = true;
				}
			}
		}

		//take photo and find targets
		//cout<<"do_tre_ms: "<<time_loader_running<<'\n'<<endl;
		cap.read(cap_result);// resolution 640x480
		findSquares(time_cap, cap_result, targets);
		sortSquares(targets, sorted_targets);
		drawSquares(cap_result, sorted_targets);
		compareTargets(time_loader_running, sorted_targets, estimate_targets);
		if (waitKey(1) == 27)
		{
			cout << "EXIT!" << endl;
		}
	}
    return 0;
}

float to_real_dimention(int type, float coor_value)
{
	float ans;
	if (type == 0)
	{
		ans = (-1)*(coor_value - 80)*0.5833333333;//(105/[(end_col - begin_col)/2]//debug
		cout<<"ans_X"<<ans<<endl;
	}
	else if (type == 1)
	{
		ans = -300 + (120 - coor_value) * 0.5833333333;//(140 / 240);
		cout<<"ans_Y"<<ans<<endl;
	}
	else
	{
		ans = 0;
	}
	return ans;
}

string Gcode_to_Position(Position _position)
{
	string Gcode;
	string G0 = "G0";
	string s_X = " X";
	string s_Y = " Y";
	string s_Z = " Z";
	Gcode = G0 + s_X + to_string(_position.X) + s_Y + to_string(_position.Y) + s_Z + to_string(_position.Z);
	return Gcode;
}

//find the center point of the rectangle
Point find_center_point(vector<Point> array)
{
	Point point;
	int max_x = 0;
	int min_x = 65536;

	int max_y = 0;
	int min_y = 65536;
	for (int i = 0; i < 4; i++)
	{
		if (array[i].x > max_x)
			max_x = array[i].x;
		if (array[i].x < min_x)
			min_x = array[i].x;

		if (array[i].y > max_y)
			max_y = array[i].y;
		if (array[i].y < min_y)
			min_y = array[i].y;		
	}
	point.x = (max_x + min_x) / 2;
	point.y = (max_y + min_y) / 2;
	return point;
}

// helper function finds a cosine of angle between vectors from pt0->pt1 and from pt0->pt2
static double angle( Point pt1, Point pt2, Point pt0 )
{
    double dx1 = pt1.x - pt0.x;
    double dy1 = pt1.y - pt0.y;
    double dx2 = pt2.x - pt0.x;
    double dy2 = pt2.y - pt0.y;
    return (dx1*dx2 + dy1*dy2)/sqrt((dx1*dx1 + dy1*dy1)*(dx2*dx2 + dy2*dy2) + 1e-10);
}

// returns sequence of squares detected on the image, the sequence is stored in the specified memory storage
static void findSquares( unsigned int time, Mat& frame,  vector<Targets>& targets)
{
	targets.clear();
	vector<vector<Point> > contours;
    Mat img_HSV, img_color, img_canny, img_blur, img_color_blue, img_color_pink;
	COLOR current_color = YELLOW;
		//down size
		frame = frame(Range(0,480),Range(begin_col,end_col));
		resize(frame, frame, Size(), 0.5, 0.5, INTER_AREA);
		// HSV color
		cvtColor(frame, img_HSV, COLOR_BGR2HSV);
	for (int k = 0; k < 1; k++)
	{
		//blur
		medianBlur(img_HSV, img_blur, 9);
		//color fillter
			inRange(img_blur, Scalar(0, 0, 0), Scalar(30, 255, 255), img_color);//yellow
			//img_color = img_color | img_color_yel;

			inRange(img_blur, Scalar(100, 0, 0), Scalar(110, 255, 255), img_color_blue);//blue
			img_color = img_color | img_color_blue;
			
			inRange(img_blur, Scalar(150, 0, 0), Scalar(180, 255, 255), img_color_pink);//pink
			img_color = img_color | img_color_pink;

		erode(img_color, img_color, getStructuringElement(MORPH_ELLIPSE, Size(5, 5)));

		//canny
		Canny(img_color, img_canny, 5, 50, 5);
		//contours
		findContours(img_canny, contours, RETR_EXTERNAL, CHAIN_APPROX_SIMPLE);

		//-----------------------------------------------------------
		//imshow("img_canny", img_canny);
		//imshow("img_color", img_color);
		//imshow("img_HSV", img_HSV);
		//imshow("img_blur", img_blur);
		//-----------------------------------------------------------

		// test each contour
		vector<Point> approx;
		Targets target;
		for( size_t i = 0; i < contours.size(); i++ )
		{
			// approximate contour with accuracy proportional to the contour perimeter
			approxPolyDP(Mat(contours[i]), approx, arcLength(Mat(contours[i]), true)*0.09, true);
			// square contours should have 4 vertices after approximation relatively large area (to filter out noisy contours) and be convex.
			// Note: absolute value of an area is used because area may be positive or negative - in accordance with the contour orientation
			if( approx.size() == 4 && fabs(contourArea(Mat(approx))) > 200 && isContourConvex(Mat(approx)) )
			{
				double maxCosine = 0;
				// find the maximum cosine of the angle between joint edges
				for( int j = 2; j < 5; j++ )
				{					
					double cosine = fabs(angle(approx[j%4], approx[j-2], approx[j-1]));
					maxCosine = MAX(maxCosine, cosine);
				}
				// if cosines of all angles are small (all angles are ~90 degree) then write quandrange vertices to resultant sequence
				if( maxCosine < 0.3 )
				{
					//dien thuoc tinh doi tuong muc tieu
					target.center = find_center_point(approx);
					if (target.center.y > 120)
					{
						target.area = contourArea(Mat(approx));
						Vec3b color = img_blur.at<Vec3b>(target.center);//(Point(target.center.x,target.center.y));
						if(color[0] > 0 &&  color[0] < 30)
						{
							current_color = YELLOW;
						}
						else if (color[0] > 90 &&  color[0] < 110)
						{
							current_color = BLUE;
						}
						else if (color[0] > 150 &&  color[0] < 180)
						{
							current_color = PINK;
						}
						target.color = current_color;
						target.time = time;
						target.contour = approx;
						//day doi tuong vao hang doi luu tru
						targets.push_back(target);						
					}
				}					
			}
		}    
	}	    
}


// the function draws all the squares in the image
static void drawSquares( Mat& image, vector<Targets>& targets)
{
    for( size_t i = 0; i < targets.size(); i++ )
    {
        const Point* p = &targets[i].contour[0];

        int n = (int)targets[i].contour.size();
        //dont detect the border
        if (p-> x > 3 && p->y > 3)
        {
          polylines(image, &p, &n, 1, true, Scalar(0,255,0), 3, LINE_AA);
        }

		//ghi thong tin toa do, mau sac, thu tu len hinh
		string x_loc = to_string((int)targets[i].center.x);
		string y_loc = to_string((int)targets[i].center.y);
		string name_color;
		switch(targets[i].color)
		{
			case YELLOW:
				name_color = "yel";
				break;
			case BLUE:
				name_color = "blue";
				break;
			case PINK: 
				name_color = "pink";	
				break;
			default:
				break;
		}
		string ID_value = to_string(targets[i].ID) + ':';
		string s = ID_value + ' ' + x_loc + ' ' + y_loc + ' ' + name_color;
		putText(image, s.c_str(), targets[i].center, FONT_HERSHEY_SIMPLEX , 0.5, Scalar(0, 69, 255), 2);	
    }
    //cout<<"rects: "<<targets.size()<<"\n";
    imshow(wndname, image);
}

void sortSquares( vector<Targets>& targets, vector<Targets>& sorted_targets )
{
	sorted_targets.clear();
	vector<Targets>::iterator it;
	int trans_ID;
	int Y_min;
	while(targets.size() > 0)
	{
		Y_min = 65536;
		trans_ID = 0;
		for (int i = 0; i < targets.size(); i ++)
		{
			if(targets[i].center.y < Y_min)
			{
				Y_min = targets[i].center.y;
				trans_ID = i;
				it = targets.begin() + i;
			}
		}
		sorted_targets.push_back(targets[trans_ID]);
		targets.erase(it);
	}
	for (int i = 0; i < sorted_targets.size(); i ++)
	{
		sorted_targets[i].ID = i;
	}	
}

void compareTargets(unsigned int time, vector<Targets>& sorted_targets, vector<Targets>& estimate_targets)
{
	for (int i = sorted_targets.size() - 1; i >= 0; i--)
	{
		for (int j = estimate_targets.size() - 1; j >= 0; j--)
		{
			if ( abs(sorted_targets[i].center.y - estimate_targets[j].new_y) < 20
				 && abs(sorted_targets[i].center.x - estimate_targets[j].center.x) < 4
				 && sorted_targets[i].color == estimate_targets[j].color)
			{
				estimate_targets[j].ID = -1;
			}
		}
	}

	for (int k = 0; k < estimate_targets.size(); k++)
	{
		if (estimate_targets[k].ID != -1)
		{
			cout<< "target gone: " << estimate_targets[k].ID <<endl;
			targets_to_execute.push_back(estimate_targets[k]);
		}
	}

	estimate_targets.clear();
	if (sorted_targets.size() > 0)
	{
		for (int t = 0; t < sorted_targets.size(); t ++)
		{
		sorted_targets[t].new_y = sorted_targets[t].center.y - time * velocity_loader_img/1000;
		estimate_targets.push_back(sorted_targets[t]);
		}
	}
}

void Gcode_send(string Gcode)
{
    Gcode += '*';
    int b = 60 - Gcode.length();
    string k(b, ' ');
	Gcode += k;
	//cout<<"PC : "<<Gcode.c_str()<<'\n'<<endl;
	serialPuts(fd, Gcode.c_str());
	serialFlush(fd);
}

string read_serial()
{
	string c = "";
	do
	{
		c += serialGetchar(fd);
	}
	while(serialDataAvail(fd));
	serialFlush(fd);
	if (c.length() <= 1) c = "no data";
	//cout<<"Robot : "<<c.c_str()<<'\n'<<endl;
	return c;
}

void get_value(int* position, string s)
{
	string delimiter = " ";
	int pos = 0;
	int i = 0;
	string token;
	s += ' ';
	while ((pos = s.find(delimiter)) != string::npos) 
	{
		token = s.substr(0, pos);
		if (i!=0)
		{
			position[i-1] = atoi(token.c_str());
		}
		i++;
		s.erase(0, pos + delimiter.length());
	}	
}

bool Gcode_generate(unsigned int time_cap, Targets target)
{
	Position end_point;
	Position current_target_position;
	current_target_position.X = (int) to_real_dimention(0, target.center.x);
	current_target_position.Y = (int) to_real_dimention(1, target.center.y) + velocity_loader * (millis() - target.time)/1000;
	current_target_position.Z = -460;
	Gcode_send(":Position");
	string c = read_serial();
	
	//tach tri so va gan vao current_position
	if (c[1] == 'P')
	{
		int _position[3];
		get_value(_position, c);
		current_position.X = _position[0];
		current_position.Y = _position[1];
		current_position.Z = _position[2];
		cout<<"current position:"<<' '<<current_position.X<<' '<<current_position.Y <<' '<< current_position.Z <<endl;
		cout<<"target position:"<<' '<<current_target_position.X<<' '<<current_target_position.Y <<' '<< current_target_position.Z<<endl;
	}
	else
	{
		cout<<"c[1] != 'P' "<<endl;
	}

	float Y;
	up_contact_position.X = current_target_position.X;
	//up_contact_position.Y = (int) Y;
	up_contact_position.Z = -410;
	contact_position.X = current_target_position.X;
	//contact_position.Y = (int) Y;
	contact_position.Z = -460;

	//find_Y()
	float robot_travel_time, target_travel_time, compare_time;
	float up_limit, down_limit;
	if (current_target_position.Y > 200)
	{
		cout<<"target_position.Y > 200 : return;"<<endl;
		return false;
	}
	if (current_target_position.Y > 0)
	{
		up_limit = 200;
	}
	else if (current_target_position.Y < 0)
	{
		up_limit = 0;
	}
	down_limit = current_target_position.Y;
	float dist = (up_limit - down_limit)/2;
	Y = down_limit;
	while(Y < up_limit && abs(dist) > 1 /*mm*/)
	{
		Y = Y + dist;
		up_contact_position.Y = (int) Y;
		contact_position.Y = (int) Y;
		robot_travel_time = TravelTime(current_position, up_contact_position) + TravelTime(up_contact_position, contact_position) + 0.9;
		target_travel_time = (Y - current_target_position.Y) / velocity_loader;
		compare_time = target_travel_time - robot_travel_time;
		if (compare_time > 0)
		{
			Y = Y - dist;
			dist = dist/2;
		}
	}
	cout<<"compare_time: "<<compare_time<<endl;
	cout<< "nghiem Y:" << Y <<endl;
	up_contact_position.Y = (int) Y;
	contact_position.Y = (int) Y;	
	switch (target.color)
	{
	case PINK:
		end_point = pink_box;
		break;
	case BLUE:
		end_point = blue_box;
		break;
	case YELLOW:
		end_point = yellow_box;
		break;	
	default:
		break;
	}
	Gcode_queue.push_back(Gcode_to_Position(up_contact_position));	//UP_CONTACT_POSITION	
	Gcode_queue.push_back("G0 V1");
	Gcode_queue.push_back(Gcode_to_Position(contact_position));	//CONTACT_POSITION
	Gcode_queue.push_back("G4 P200");	//WAIT TO GRAB
	Gcode_queue.push_back(Gcode_to_Position(up_contact_position));	//UP_CONTACT_POSITION	
	Gcode_queue.push_back(Gcode_to_Position(end_point));	//BOX
	Gcode_queue.push_back("G0 V0");
	Gcode_queue.push_back("G4 P1000");	//WAIT TO RELEASE
	Gcode_queue.push_back("M11");	//SIGNAL :DONE
	for (int i = 0; i < Gcode_queue.size(); i++)
	{
		cout<<Gcode_queue[i]<<endl;
	}
	return true;
}

Position GetPointInLine(Position currentP, Position desiredP, float t)
{
	Position buffer;

	buffer.X = currentP.X - ((currentP.X - desiredP.X) * t);
	buffer.Y = currentP.Y - ((currentP.Y - desiredP.Y) * t);
	buffer.Z = currentP.Z - ((currentP.Z - desiredP.Z) * t);

	return buffer;
}

float CalDistance2Point(Position point1, Position point2)
{
	float x_Offset = point1.X - point2.X;
	float y_Offset = point1.Y - point2.Y;
	float z_Offset = point1.Z - point2.Z;

	float distance = sqrt(pow(x_Offset, 2) + pow(y_Offset, 2) + pow(z_Offset, 2));

	if (distance < 0.2 && distance > -0.2)
		distance = 0;

	return distance;
}

float TravelTime(Position CurrentPoint, Position DesiredPoint)
{
	float distance2Point = CalDistance2Point(CurrentPoint, DesiredPoint);
	if (distance2Point == 0)
	{
		return 0;
	}
	int NumberSegment = floorf(distance2Point / MMPerLinearSegment);
	float tbuffer;
	V_planner.plan(distance2Point);
	V_planner.lastV = V_planner.V_atPoint_Cal(0);
	float mm_per_seg = distance2Point / NumberSegment;
	for (uint16_t i = 1; i <= NumberSegment; i++)
	{
		tbuffer = (float)i / NumberSegment;
		Position pointBuffer = GetPointInLine(CurrentPoint, DesiredPoint, tbuffer);
		float currentV = V_planner.V_atPoint_Cal((float) mm_per_seg*i);
		float moving_time;
		moving_time = V_planner.V_Moving_Time_Cal(mm_per_seg, V_planner.lastV, currentV);
		V_planner.lastV = currentV;
		V_planner.T += moving_time;
	}
	float estimate_time = V_planner.T;
	V_planner.T = 0;
	return estimate_time;
}