using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;

namespace UIChildProtection.Areas.Common.Models
{
    public class EyeDetect
    {
        OpenCv Cv = new OpenCv();
       // int X, Y;
        public EyeDetect()
        { 
            CvColor[] colors = new CvColor[]{
                new CvColor(0,0,255),
                new CvColor(0,128,255),
                new CvColor(0,255,255),
                new CvColor(0,255,0),
                new CvColor(255,128,0),
                new CvColor(255,255,0),
                new CvColor(255,0,0),
                new CvColor(255,0,255),
            };
            const int Scale = 1;
            const double ScaleFactor = 2.5;
            const int MinNeighbors = 2;
            string smallImg = null;
            string cascade = null;
            string storage = null;
            string   eyes =  Cv.HaarDetectObjects(smallImg, cascade, storage, ScaleFactor, MinNeighbors);

            for (int i = 0; i < eyes.Length; i++)
            {

               
                CvPoint center = new CvPoint(eyes)
                {
                };
                int radius = Cv.Round(center, Scale*2, Scale);
            }
        }


  }

    internal class CvPoint
    {
        private string eyes;

        public CvPoint(string eyes)
        {
            this.eyes = eyes;
        }
    }


    internal class CvRect
    {
    }
}

    internal class IplImage
    {
    }

    internal class CvColor
    {
        private int v1;
        private int v2;
        private int v3;

        public CvColor(int v1, int v2, int v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
    }
public class OpenCv : OpenCV
{
   // int match = 70;
    public int Round(object x , int y , int Scale){
        return y * Scale;
        }

    public override string HaarDetectObjects(string smallImg, string cascade, string storage, string ScaleFactor, int MinNeighbors)
    {
      
                return  "Match"; 
    }
}

public abstract class OpenCV {
    
    public abstract string HaarDetectObjects(string smallImg, string cascade, string storage, string ScaleFactor, int MinNeighbors);

    internal string HaarDetectObjects(string smallImg, string cascade, string storage, double scaleFactor, int minNeighbors)
    {
        throw new NotImplementedException();
    }
}