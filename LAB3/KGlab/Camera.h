#ifndef CAMERA_H
#define CAMERA_H

#include "MyOGL.h"

class Camera
{
	double camDist = 5;

	int camNz = 1;

	double camX;
	double camY;
	double camZ;
	int mouseX = -1, mouseY = -1;

	bool drag = false;

public:
	//начальные углы камеры
	double _fi1 = 1;
	double _fi2 = 0.5;

	Camera()
	{
		caclulateCameraPos();
	}

	void setPosition(double x, double y, double z);

	double distance()
	{
		return camDist;
	}

	int nZ() const
	{
		return camNz;
	}
	double x() const
	{
		return  camX;
	}
	double y() const
	{
		return  camY;
	}
	double z() const
	{
		return  camZ;
	}
	double fi1() const
	{
		return  _fi1;
	}
	double fi2() const
	{
		return  _fi2;
	}

	void caclulateCameraPos();
	void Zoom(OpenGL* sender, MouseWheelEventArg arg);
	void MouseMovie(OpenGL* sender, MouseEventArg arg);

	void MouseLeave(OpenGL* sender, MouseEventArg arg)
	{
		mouseX = -1;
	}

	void MouseStartDrag(OpenGL* sender, MouseEventArg arg)
	{
		drag = true;
	}

	void MouseStopDrag(OpenGL* sender, MouseEventArg arg)
	{
		drag = false;
		mouseX = -1;
	}

	void SetUpCamera();

};

#endif