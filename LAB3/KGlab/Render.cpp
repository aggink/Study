#include "Render.h"
#include <Windows.h>
#include <GL\GL.h>
#include <GL\GLU.h>
#include <vector>
#include <cmath>
#define pi 3.1415926535

using namespace std;

struct Point3D {
    double x, y, z;
    Point3D(double x = 0, double y = 0, double z = 0) : x(x), y(y), z(z) {}
};

// Параметры анимации
Point3D figurePos(0, 0, 0);
vector<Point3D> bSplinePoints;
double animTime = 0;
const double animSpeed = 0.0008;

// Функции для кривых
double Beze2(double p0, double p1, double t) {
    return pow(1 - t, 2) * p0 + 2 * t * (1 - t) * p1;
}

double Beze3(double p0, double p1, double t) {
    return pow(1 - t, 3) * p0 + 3 * t * pow(1 - t, 2) * p1;
}

double Ermit(double r1, double p1, double r4, double p4, double t) {
    return p1 * (2 * pow(t, 3) - 3 * pow(t, 2) + 1) +
        p4 * (-2 * pow(t, 3) + 3 * pow(t, 2)) +
        r1 * (pow(t, 3) - 2 * pow(t, 2) + t) +
        r4 * (pow(t, 3) - pow(t, 2));
}

// Функции отрисовки кривых
void createBeze2(double P0[], double P1[], double delta_time) {
    double P[3];

    glPointSize(10);
    glColor3d(1, 0, 0);
    glBegin(GL_POINTS);
    glVertex3dv(P0);
    glVertex3dv(P1);
    glEnd();

    glLineWidth(1);
    glColor3d(0.5, 0.5, 0.5);
    glBegin(GL_LINE_STRIP);
    glVertex3dv(P0);
    glVertex3dv(P1);
    glEnd();

    glLineWidth(3);
    glColor3d(0, 0, 1);
    glBegin(GL_LINE_STRIP);
    for (double t = 0; t <= 1.001; t += 0.01) {
        P[0] = Beze2(P0[0], P1[0], t);
        P[1] = Beze2(P0[1], P1[1], t);
        P[2] = Beze2(P0[2], P1[2], t);
        glVertex3dv(P);
    }
    glEnd();
}

void createBeze3(double P0[], double P1[], double delta_time) {
    double P[3];

    glPointSize(10);
    glColor3d(1, 0, 0);
    glBegin(GL_POINTS);
    glVertex3dv(P0);
    glVertex3dv(P1);
    glEnd();

    glLineWidth(1);
    glColor3d(0.5, 0.5, 0.5);
    glBegin(GL_LINE_STRIP);
    glVertex3dv(P0);
    glVertex3dv(P1);
    glEnd();

    glLineWidth(3);
    glColor3d(0, 0.5, 0);
    glBegin(GL_LINE_STRIP);
    for (double t = 0; t <= 1.001; t += 0.01) {
        P[0] = Beze3(P0[0], P1[0], t);
        P[1] = Beze3(P0[1], P1[1], t);
        P[2] = Beze3(P0[2], P1[2], t);
        glVertex3dv(P);
    }
    glEnd();
}

void createErmit(double R1[], double P1[], double R4[], double P4[]) {
    double P[3];

    glPointSize(10);
    glColor3d(1, 0, 1);
    glBegin(GL_POINTS);
    glVertex3dv(P1);
    glVertex3dv(P4);
    glEnd();

    glLineWidth(1);
    glColor3d(0.5, 0, 0.5);
    glBegin(GL_LINES);
    glVertex3dv(P1);
    glVertex3dv(R1);
    glVertex3dv(P4);
    glVertex3dv(R4);
    glEnd();

    glLineWidth(3);
    glColor3d(1, 0.5, 0);
    glBegin(GL_LINE_STRIP);
    for (double t = 0; t <= 1.001; t += 0.01) {
        P[0] = Ermit(R1[0], P1[0], R4[0], P4[0], t);
        P[1] = Ermit(R1[1], P1[1], R4[1], P4[1], t);
        P[2] = Ermit(R1[2], P1[2], R4[2], P4[2], t);
        glVertex3dv(P);
    }
    glEnd();
}

// Функция для рисования буквы ᛒ
void drawLetterD() {
    // Вертикальная линия буквы ᛒ
    double lineP0[] = { -4, -6, 0 };
    double lineP1[] = { -4, 6, 0 };

    glLineWidth(4);
    glColor3d(1, 0, 0);
    glBegin(GL_LINES);
    glVertex3dv(lineP0);
    glVertex3dv(lineP1);
    glEnd();

    // Верхний треугольник буквы ᛒ
    double bez1P0[] = { -4, 6, 0 };
    double bez1P1[] = { 2, 3, 0 };

    double bez2P0[] = { 2, 3, 0 };
    double bez2P1[] = { -4, 0, 0 };

    // Нижний треугольник буквы ᛒ
    double bez3P0[] = { -4, 0, 0 };
    double bez3P1[] = { 2, -3, 0 };

    double bez4P0[] = { 2, -3, 0 };
    double bez4P1[] = { -4, -6, 0 };

    createBeze3(bez1P0, bez1P1, 0);
    createBeze3(bez2P0, bez2P1, 0);
    createBeze3(bez3P0, bez3P1, 0);
    createBeze3(bez4P0, bez4P1, 0);

    glLineWidth(3);
    glColor3d(1, 0, 0);

    glBegin(GL_LINES);
    glVertex3dv(bez1P0);
    glVertex3dv(bez1P1);
    glVertex3dv(bez2P0);
    glVertex3dv(bez2P1);
    glEnd();

    glBegin(GL_LINES);
    glVertex3dv(bez3P0);
    glVertex3dv(bez3P1);
    glVertex3dv(bez4P0);
    glVertex3dv(bez4P1);
    glEnd();
}

// B-spline функции
double basisFunction(int i, int k, double t, const vector<double>& knots) {
    if (k == 0) return (t >= knots[i] && t < knots[i + 1]) ? 1.0 : 0.0;

    double denom1 = knots[i + k] - knots[i];
    double denom2 = knots[i + k + 1] - knots[i + 1];

    double term1 = (denom1 != 0) ? ((t - knots[i]) / denom1) * basisFunction(i, k - 1, t, knots) : 0;
    double term2 = (denom2 != 0) ? ((knots[i + k + 1] - t) / denom2) * basisFunction(i + 1, k - 1, t, knots) : 0;

    return term1 + term2;
}

Point3D computeBSpline(double t) {
    int n = bSplinePoints.size() - 1;
    int k = 2;

    vector<double> knots;
    for (int i = 0; i <= k; i++) knots.push_back(0);
    for (int i = 1; i < n - k + 1; i++) knots.push_back(i / double(n - k + 1));
    for (int i = 0; i <= k; i++) knots.push_back(1);

    Point3D result(0, 0, 0);
    double sum = 0;

    for (int i = 0; i <= n; i++) {
        double basis = basisFunction(i, k, t, knots);
        result.x += bSplinePoints[i].x * basis;
        result.y += bSplinePoints[i].y * basis;
        result.z += bSplinePoints[i].z * basis;
        sum += basis;
    }

    if (sum != 0) {
        result.x /= sum;
        result.y /= sum;
        result.z /= sum;
    }

    return result;
}

void initBSplinePoints() {
    bSplinePoints.clear();
    bSplinePoints.push_back(Point3D(-10, 2, 0));
    bSplinePoints.push_back(Point3D(-8, 5, 0));
    bSplinePoints.push_back(Point3D(-5, 1, 0));
    bSplinePoints.push_back(Point3D(0, 6, 0));
    bSplinePoints.push_back(Point3D(5, 2, 0));
    bSplinePoints.push_back(Point3D(8, 4, 0));
    bSplinePoints.push_back(Point3D(10, 3, 0));
}

void drawBSpline() {
    glLineWidth(3);
    glColor3d(0.2, 0.4, 0.8);
    glBegin(GL_LINE_STRIP);

    for (double t = 0; t <= 1.0; t += 0.0015) {
        Point3D p = computeBSpline(t);
        glVertex3d(p.x, p.y, p.z);
    }

    glEnd();

    glPointSize(12);
    glColor3d(0.8, 0.2, 0.2);
    glBegin(GL_POINTS);
    for (const auto& p : bSplinePoints) {
        glVertex3d(p.x, p.y, p.z);
    }
    glEnd();
}

void drawFigure() {
    glPushMatrix();
    glTranslatef(figurePos.x, figurePos.y, figurePos.z);

    // Нижняя грань
    glBegin(GL_POLYGON);
    glColor3d(0.2, 0.9, 0.5);
    glVertex3d(-0.5, 0.0, 0.0);  // A
    glVertex3d(-3.0, -2.0, 0.0); // B
    glVertex3d(0.5, -4.0, 0.0);  // C
    glVertex3d(2.0, -2.0, 0.0);  // D
    glVertex3d(0.5, 0.0, 0.0);   // E
    glVertex3d(2.5, 2.5, 0.0);   // F
    glVertex3d(0.0, 4.5, 0.0);   // G
    glVertex3d(-3.0, 2.0, 0.0);  // H
    glEnd();

    // Верхняя грань
    glBegin(GL_POLYGON);
    glColor3d(0.9, 0.2, 0.4);
    glVertex3d(-0.5, 0.0, 2.0);  // A1
    glVertex3d(-3.0, -2.0, 2.0); // B1
    glVertex3d(0.5, -4.0, 2.0);  // C1
    glVertex3d(2.0, -2.0, 2.0);  // D1
    glVertex3d(0.5, 0.0, 2.0);   // E1
    glVertex3d(2.5, 2.5, 2.0);   // F1
    glVertex3d(0.0, 4.5, 2.0);   // G1
    glVertex3d(-3.0, 2.0, 2.0);  // H1
    glEnd();

    // Боковые грани
    glBegin(GL_QUADS);
    glColor3d(0.1, 0.5, 0.9);

    // Грань ABB1A1
    glVertex3d(-0.5, 0.0, 0.0); glVertex3d(-0.5, 0.0, 2.0);
    glVertex3d(-3.0, -2.0, 2.0); glVertex3d(-3.0, -2.0, 0.0);

    // Грань BCC1B1
    glVertex3d(-3.0, -2.0, 0.0); glVertex3d(-3.0, -2.0, 2.0);
    glVertex3d(0.5, -4.0, 2.0); glVertex3d(0.5, -4.0, 0.0);

    // Грань CDD1C1
    glVertex3d(0.5, -4.0, 0.0); glVertex3d(0.5, -4.0, 2.0);
    glVertex3d(2.0, -2.0, 2.0); glVertex3d(2.0, -2.0, 0.0);

    // Грань DEE1D1
    glVertex3d(2.0, -2.0, 0.0); glVertex3d(2.0, -2.0, 2.0);
    glVertex3d(0.5, 0.0, 2.0); glVertex3d(0.5, 0.0, 0.0);

    // Грань EFF1E1
    glVertex3d(0.5, 0.0, 0.0); glVertex3d(0.5, 0.0, 2.0);
    glVertex3d(2.5, 2.5, 2.0); glVertex3d(2.5, 2.5, 0.0);

    // Грань FGG1F1
    glVertex3d(2.5, 2.5, 0.0); glVertex3d(2.5, 2.5, 2.0);
    glVertex3d(0.0, 4.5, 2.0); glVertex3d(0.0, 4.5, 0.0);

    // Грань GHH1G1
    glVertex3d(0.0, 4.5, 0.0); glVertex3d(0.0, 4.5, 2.0);
    glVertex3d(-3.0, 2.0, 2.0); glVertex3d(-3.0, 2.0, 0.0);

    // Грань HAA1H1
    glVertex3d(-3.0, 2.0, 0.0); glVertex3d(-3.0, 2.0, 2.0);
    glVertex3d(-0.5, 0.0, 2.0); glVertex3d(-0.5, 0.0, 0.0);
    glEnd();

    // Заменяем круглые части на треугольный веер между точками G и H
    double radius = sqrt(pow(0.0 - (-3.0), 2) + pow(4.5 - 2.0, 2)) / 2.0;
    double center_x = (-3.0 + 0.0) / 2.0;
    double center_y = (2.0 + 4.5) / 2.0;
    int num_triangles = 180;

    // Нижний треугольный веер
    glBegin(GL_TRIANGLES);
    for (int i = 0; i < num_triangles; i++) {
        double angle1 = atan2(2.0 - center_y, -3.0 - center_x) - (double)i / num_triangles * 3.1415;
        double angle2 = atan2(2.0 - center_y, -3.0 - center_x) - (double)(i + 1) / num_triangles * 3.1415;

        double x1 = center_x + radius * cos(angle1);
        double y1 = center_y + radius * sin(angle1);
        double x2 = center_x + radius * cos(angle2);
        double y2 = center_y + radius * sin(angle2);

        glColor3d(0.2, 0.9, 0.);
        glVertex3d(x1, y1, 0.0);
        glVertex3d(x2, y2, 0.0);
        glVertex3d(center_x, center_y, 0.0);
    }
    glEnd();

    // Верхний треугольный веер
    glBegin(GL_TRIANGLES);
    for (int i = 0; i < num_triangles; i++) {
        double angle1 = atan2(2.0 - center_y, -3.0 - center_x) - (double)i / num_triangles * 3.1415;
        double angle2 = atan2(2.0 - center_y, -3.0 - center_x) - (double)(i + 1) / num_triangles * 3.1415;

        double x1 = center_x + radius * cos(angle1);
        double y1 = center_y + radius * sin(angle1);
        double x2 = center_x + radius * cos(angle2);
        double y2 = center_y + radius * sin(angle2);

        glColor3d(0.9, 0.2, 0.4);
        glVertex3d(x1, y1, 2.0);
        glVertex3d(x2, y2, 2.0);
        glVertex3d(center_x, center_y, 2.0);
    }
    glEnd();

    // Боковые грани между верхним и нижним веерами
    glBegin(GL_QUADS);
    glColor3d(0.1, 0.5, 0.9);
    for (int i = 0; i < num_triangles; i++) {
        double angle = atan2(2.0 - center_y, -3.0 - center_x) - (double)i / num_triangles * 3.1415;
        double next_angle = atan2(2.0 - center_y, -3.0 - center_x) - (double)(i + 1) / num_triangles * 3.1415;

        double x = center_x + radius * cos(angle);
        double y = center_y + radius * sin(angle);
        double nx = center_x + radius * cos(next_angle);
        double ny = center_y + radius * sin(next_angle);

        glVertex3d(x, y, 0.0);
        glVertex3d(x, y, 2.0);
        glVertex3d(nx, ny, 2.0);
        glVertex3d(nx, ny, 0.0);
    }
    glEnd();

    glPopMatrix();
}

void updateFigurePosition() {
    animTime += animSpeed;
    if (animTime > 1.0) animTime -= 1.0;
    figurePos = computeBSpline(animTime);
}

void Render(double delta_time) {
    static bool initialized = false;
    if (!initialized) {
        initBSplinePoints();
        initialized = true;
    }

    updateFigurePosition();

    // Задание на 25 баллов
    double bez2P0[] = { -10, 0, 0 };
    double bez2P1[] = { -5, 8, 0 };
    double bez2P2[] = { 0, 0, 0 };
    createBeze2(bez2P0, bez2P1, delta_time);

    double ermP1[] = { 2, -5, 0 };
    double ermR1[] = { 7, -2, 0 };
    double ermP4[] = { 10, -5, 0 };
    double ermR4[] = { 5, -8, 0 };
    createErmit(ermR1, ermP1, ermR4, ermP4);

    double bez3P0[] = { 5, 5, 0 };
    double bez3P1[] = { 10, 10, 0 };
    double bez3P2[] = { 15, 0, 0 };
    double bez3P3[] = { 20, 5, 0 };
    createBeze3(bez3P0, bez3P1, delta_time);

    // Задание на 30 баллов - буква D
    drawLetterD();

    // Анимация фигуры по B-сплайну
    drawBSpline();
    drawFigure();
}