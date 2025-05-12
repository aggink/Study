#include "Camera.h"

#include <windows.h>
#include <gl/GL.h>
#include <gl/GLU.h>

void Camera::setPosition(double x, double y, double z)
{
	camX = x;
	camY = y;
	camZ = z;


	camDist = sqrt(x * x + y * y + z * z);

	_fi1 = atan2(y, x);
	_fi2 = atan2(z,sqrt(x*x+y*y));
}

void Camera::caclulateCameraPos()
{
	camX = camDist * cos(_fi2) * cos(_fi1);
	camY = camDist * cos(_fi2) * sin(_fi1);
	camZ = camDist * sin(_fi2);
	if (cos(_fi2) <= 0)
		camNz = -1;
	else
		camNz = 1;
}

void Camera::Zoom(OpenGL* sender, MouseWheelEventArg arg)
{
	if (arg.value < 0 && camDist <= 1)
		return;
	if (arg.value > 0 && camDist >= 100)
		return;

	camDist += 0.01 * arg.value;

	caclulateCameraPos();
}

void Camera::MouseMovie(OpenGL* sender, MouseEventArg arg)
{
	if (OpenGL::isKeyPressed('G'))
		return;

	if (mouseX == -1)
	{
		mouseX = arg.x;
		mouseY = arg.y;
		return;
	}
	int dx = mouseX - arg.x;
	int dy = mouseY - arg.y;
	mouseX = arg.x;
	mouseY = arg.y;

	if (drag)
	{
		_fi1 = _fi1 + 0.01 * dx;
		_fi2 = _fi2 - 0.01 * dy;

		caclulateCameraPos();
	}
}



void Camera::SetUpCamera()
{
	//сообщаем openGL настройки нашей камеры,
	// где она находится и куда смотрит
	// https://learn.microsoft.com/ru-ru/windows/win32/opengl/glulookat
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	gluLookAt(camX, camY, camZ, 0, 0, 0, 0, 0, camNz);
}
