using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_map
{
    public class CurrentAngle
    {
        public double Longitude(double degree, double minutes, double seconds)
        {
            double longitude = degree;
            double long_min = minutes;
            double long_sec = seconds;
            long_min += long_sec / 60;
            longitude += long_min / 60;
            return longitude;
        }

        public double Latitude(double degree, double minutes, double seconds)
        {
            double latitude = degree;
            double lat_min = minutes;
            double lat_sec = seconds;
            lat_min += lat_sec / 60;
            latitude += lat_min / 60;
            return latitude;
        }

        public double d(DateTime date)
        {
            double a = (14.0 - date.Month) / 12.0;
            int y = (date.Year) + 4800 -(int)a;
            int m = date.Month + 12 * (int)a - 3;

            double JDN = date.Day + ((153 * m + 2) / 5) + 365 * y + (y / 4)
                - (y / 100) + (y / 400) - 32045;
            return JDN + (date.Hour - 12.0) / 24.0 + (date.Minute / 1440.0) + (date.Second / 86400.0) - 2451543.5;
        }

        public double w(double d)
        {
            return 282.9404 + 4.70935e-5 * d;
        }

        public double M(double d)
        {
            return rev(356.0470 + 0.9856002585 * d);
        }

        public double L(double M, double w)
        {
            return rev(M + w);
        }

        public double GMST0(double L)
        {     
            return rev((L + 180) / 15);
        }

        public double CurAng(double zhor)
        {
            return Math.Asin(zhor);
        }

        public double zhor(double x, double z, double latitude)
        {
            return x * Math.Cos((latitude * Math.PI) / 180) + z * Math.Sin((latitude * Math.PI) / 180);
        }

        public double X(double HA, double Decl)
        {
            return (Math.Cos((HA * Math.PI) / 180) * Math.Cos((Decl * Math.PI) / 180));
        }

        public double Y(double HA, double Decl)
        {
            return (Math.Sin(HA) * Math.Cos(Decl));
        }

        public double Z(double Decl)
        {
            return Math.Sin((Decl * Math.PI) / 180);
        }

        public double HA(double SIDTIME, double RA)
        {
            return (SIDTIME - RA)*15;
        }

        public double RA(double xequat, double yequat)
        {
            return (Math.Atan2(yequat, xequat) * 180)/ Math.PI/15;
        }

        public double Decl(double xequat, double yequat, double zequat)
        {
            return (Math.Atan2(zequat, (xequat * xequat) + (yequat * yequat))*180)/Math.PI;
        }

        public double xequat(double xeclip)
        {
            return xeclip;
        }

        public double yequat(double yeclip, double zeclip, double oblecl)
        {
            return yeclip * Math.Cos((oblecl * Math.PI) / 180) - zeclip * Math.Sin((oblecl * Math.PI) / 180);
        }

        public double zequat(double yeclip, double zeclip, double oblecl)
        {
            return yeclip * Math.Sin((oblecl * Math.PI) / 180) + zeclip * Math.Cos((oblecl * Math.PI) / 180);
        }

        public double oblecl(double d)
        {
            return 23.4393 - 3.563e-7 * d;
        }

        public double xeclip(double longitude, double r)
        {
            return r * Math.Cos((longitude * Math.PI) / 180);
        }

        public double yeclip(double longitude, double r)
        {
            return r * Math.Sin((longitude * Math.PI) / 180);
        }

        public double zeclip(double latitude)
        {
            return (Math.Sin(latitude));
        }

        public double SIDTIME(double GSMT0, DateTime UT, double longitude)
        {
            double ut = UT.Hour;
            double ut_minutes = UT.Minute + UT.Second / 60;
            ut += ut_minutes/60;
            return GSMT0 + ut + longitude/ 15;
        }

        public double e(double d)
        {
            return 0.016709 - 1.151E-9 * d;
        }

        public double E(double M, double e)
        {
            double deg = (M * Math.PI) / 180;
            return M + (180.0 / Math.PI)*e* Math.Sin(deg)* (1.0 + e * Math.Cos(deg)); ;
        }

        public double sun_x(double E, double e)
        {
            return Math.Cos((E * Math.PI) / 180) - e;
        }

        public double sun_y(double E, double e)
        {
            return Math.Sin((E * Math.PI) / 180) * Math.Sqrt(1 - (e * e));
        }

        public double r (double x, double y)
        {
            return Math.Sqrt((x * x + y * y));
        }

        public double v(double x, double y)
        {
            
            return (Math.Atan2((y * Math.PI) / 180, (x * Math.PI) / 180)*180)/Math.PI;
        }

        public double sun_lon(double v, double w)
        {
            return rev(v + w);
        }

        public double CalculateAngle(double lon_degrees, double lon_min, double lon_sec, double lat_degrees, double lat_min, double lat_sec, DateTime date)
        {
         
            double cur_angle;
            double lon = Longitude(lon_degrees, lon_min, lon_sec);
            double lat = Latitude(lat_degrees, lat_min, lat_sec);

            double D = d(date);

            double m = M(D);
            double W = w(D);

            double l = L(m, W);
            double oblec = oblecl(D);

            double e_k = e(D);
            double E_k = E(m, e_k);

            double x_s = sun_x(E_k, e_k);
            double y_s = sun_y(E_k, e_k);

            double R = r(x_s, y_s);
            double V = v(x_s, y_s);

            double lon_s = sun_lon(V, W);

            double xecl = xeclip(lon_s, R);
            double yecl = yeclip(lon_s, R);
            double zecl = 0;



            double xeq = xequat(xecl);
            double yeq = yequat(yecl, zecl, oblec);
            double zeq = zequat(yecl, zecl, oblec);

            double decl = Decl(xeq, yeq, zeq);
            double ra = RA(xeq, yeq);

         


            double gsmt0 = GMST0(l);

            double sid = SIDTIME(gsmt0, date, lon);
            double ha = HA(sid, ra);

            double x = X(ha, decl);
            double z = Z(decl);

            double zh = zhor(x, z, lat);

            cur_angle = (Math.Asin(zh) * 180) / Math.PI;

            return cur_angle;
        }

        public double rev(double degree)
        {
            int buf = (int)degree / 360;
            degree = degree - buf * 360;
            if(degree < 0)
            {
                degree = 360 + degree;
            }
            return degree;
        }

        public double Angle_Coefficient(double lon_degrees, double lon_min, double lon_sec, double lat_degrees, double lat_min, double lat_sec, DateTime date)
        {
            double cur_ang = CalculateAngle(lon_degrees, lon_min, lon_sec, lat_degrees,lat_min, lat_sec,date);
            return 1 / (Math.Tan((90  - Math.Abs (cur_ang) )* Math.PI / 180) / Math.Sin((90 - Math.Abs(cur_ang)) * Math.PI / 180));
            
        }
    }


}
