using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UberTest : MonoBehaviour
{

    #region painter
    public Texture2D sourceBaseTex;
    private Texture2D baseTex;

    void Start()
    {
        baseTex = (Texture2D)Instantiate(sourceBaseTex);
    }


    private Vector2 dragStart;
    private Vector2 dragEnd;
    public enum Tool
    {
        
        Brush,
        Eraser
    }
    private int tool2 = 0;
    public Samples AntiAlias = Samples.Samples4;
    public Tool tool = Tool.Brush;
    public Texture[] toolimgs;
    public Texture2D colorCircle;
    public float lineWidth = 1;
    public float strokeWidth = 1;
    public Color col = Color.black;
    public Color col2 = Color.black;
    public GUISkin gskin;
   
    public BrushTool brush = new BrushTool();
    public EraserTool eraser = new EraserTool();

    public int zoom = 1;


    public int toolbargroesse = 0;
    public Texture[] sprayGroesse;

    public int toolbarfarbe =0;
    public Texture[] sprayFarbe;

    void OnGUI()
    {
        GUI.skin = gskin;

        GUILayout.BeginArea(new Rect(5, 5, 100 + baseTex.width * zoom, baseTex.height * zoom), "", "Box");
        GUILayout.BeginArea(new Rect(0, 0, 100, baseTex.height * zoom));
        tool2 = GUILayout.Toolbar(tool2, toolimgs, "Tool");
        
        	tool = (Tool)System.Enum.Parse(typeof(Tool),tool2.ToString());

        


        GUILayout.Label("Zeichen Optionen");
        GUILayout.Space(10);
        switch (tool)
        {
            case Tool.Brush:
        
                GUILayout.Label("Spray größe " + brush.width );
                toolbargroesse = GUILayout.Toolbar(toolbargroesse, sprayGroesse, "SprayGroesse");
                brush.width = brushGroesse(toolbargroesse);
                brush.hardness = 5;
                GUILayout.Label("Spray Farbe ");
                
               toolbarfarbe = GUILayout.SelectionGrid(toolbarfarbe, sprayFarbe, 3);
               col = brushColor(toolbarfarbe);
                break;

            case Tool.Eraser:
                GUILayout.Label("Spray größe " + eraser.width );
                toolbargroesse = GUILayout.Toolbar(toolbargroesse, sprayGroesse, "SprayGroesse");
                eraser.width = brushGroesse(toolbargroesse);
                eraser.hardness = 5;
                break;
         }       


        GUILayout.EndArea();
        GUI.DrawTexture(new Rect(100, 0, baseTex.width * zoom, baseTex.height * zoom), baseTex);
        GUILayout.EndArea();
    }
    private Vector2 preDrag;
    void Update()
    {
        Rect imgRect = new Rect(5 + 100, 5, baseTex.width * zoom, baseTex.height * zoom);
        Vector2 mouse = Input.mousePosition;
        mouse.y = Screen.height - mouse.y;

      
        if (Input.GetKeyDown("mouse 0"))
        {
            Debug.Log("mouse0");
            if (imgRect.Contains(mouse))
            {

                dragStart = mouse - new Vector2(imgRect.x, imgRect.y);
                dragStart.y = imgRect.height - dragStart.y;
                dragStart.x = Mathf.Round(dragStart.x / zoom);
                dragStart.y = Mathf.Round(dragStart.y / zoom);
                //LineStart (mouse - Vector2 (imgRect.x,imgRect.y));

                dragEnd = mouse - new Vector2(imgRect.x, imgRect.y);
                dragEnd.x = Mathf.Clamp(dragEnd.x, 0, imgRect.width);
                dragEnd.y = imgRect.height - Mathf.Clamp(dragEnd.y, 0, imgRect.height);
                dragEnd.x = Mathf.Round(dragEnd.x / zoom);
                dragEnd.y = Mathf.Round(dragEnd.y / zoom);
            }
            else
            {
                dragStart = Vector3.zero;
            }

        }
        if (Input.GetKey("mouse 0"))
        {
            if (dragStart == Vector2.zero)
            {
                return;
            }
            dragEnd = mouse - new Vector2(imgRect.x, imgRect.y);
            dragEnd.x = Mathf.Clamp(dragEnd.x, 0, imgRect.width);
            dragEnd.y = imgRect.height - Mathf.Clamp(dragEnd.y, 0, imgRect.height);
            dragEnd.x = Mathf.Round(dragEnd.x / zoom);
            dragEnd.y = Mathf.Round(dragEnd.y / zoom);

            if (tool == Tool.Brush)
            {
                Debug.Log("brush");
                Brush(dragEnd, preDrag);
            }
            if (tool == Tool.Eraser)
            {
                Debug.Log("eraser");
                Eraser(dragEnd, preDrag);
            }

        }
        if (Input.GetKeyUp("mouse 0") && dragStart != Vector2.zero)
        {
            dragStart = Vector2.zero;
            dragEnd = Vector2.zero;
        }
        preDrag = dragEnd;
    }

    void Brush(Vector2 p1, Vector2 p2)
    {
        
        NumSamples = AntiAlias;
        if (p2 == Vector2.zero)
        {
            p2 = p1;
        }
 
        PaintLine(p1, p2, brush.width, col, brush.hardness, baseTex);
        baseTex.Apply();
    }

    void Eraser(Vector2 p1, Vector2 p2)
    {
        NumSamples = AntiAlias;
        if (p2 == Vector2.zero)
        {
            p2 = p1;
        }
        PaintLine(p1, p2, eraser.width, Color.white, eraser.hardness, baseTex);
        baseTex.Apply();
    }



 
    public class EraserTool
    {
        public float width = 1;
        public float hardness = 1;
    }
    public class BrushTool
    {
        public float width = 1;
        public float hardness = 0;
        public float spacing = 10;
    }
    #endregion

    #region gui controls

    static Color brushColor(int toolbarfarbe)
    {
        Color brushfarbe = Color.red;
        switch (toolbarfarbe)
        {
            case 0:
                return Color.black;
            case 1:
                return Color.blue;
            case 2:
                return Color.cyan;
            case 3:
                return Color.gray;
            case 4:
                return Color.green;
            case 5:
                return Color.magenta;
            case 6:
                return Color.red;
            case 7:
                return Color.yellow;

        }
        return brushfarbe;
    }
    static int brushGroesse(int toolbargroesse)
    {
        int brushgroeße=6;
        switch (toolbargroesse)
        {
            case 0:
                brushgroeße = 3;
                return brushgroeße;
                
            case 1:
                brushgroeße = 6;
                return brushgroeße;
                
            case 2:
                brushgroeße = 9;
                return brushgroeße;
            case 3:
                brushgroeße = 12;
                return brushgroeße;

        }
        return brushgroeße;
    }


  
    #endregion

    #region drawing

    public enum Samples
    {
        None,
        Samples2,
        Samples4,
        Samples8,
        Samples16,
        Samples32,
        RotatedDisc
    }

    static Samples NumSamples = Samples.Samples4;



   

  

    static Texture2D PaintLine(Vector2 from, Vector2 to, float rad, Color col, float hardness, Texture2D tex)
    {
        var width = rad * 2;

        var extent = rad;
        var stY = Mathf.Clamp(Mathf.Min(from.y, to.y) - extent, 0, tex.height);
        var stX = Mathf.Clamp(Mathf.Min(from.x, to.x) - extent, 0, tex.width);
        var endY = Mathf.Clamp(Mathf.Max(from.y, to.y) + extent, 0, tex.height);
        var endX = Mathf.Clamp(Mathf.Max(from.x, to.x) + extent, 0, tex.width);

        var lengthX = endX - stX;
        var lengthY = endY - stY;

        var sqrRad = rad * rad;
        var sqrRad2 = (rad + 1) * (rad + 1);
        Color[] pixels = tex.GetPixels((int)stX, (int)stY, (int)lengthX, (int)lengthY, 0);
        var start = new Vector2(stX, stY);
        //Debug.Log (widthX + "   "+ widthY + "   "+ widthX*widthY);
        for (int y = 0; y < (int)lengthY; y++)
        {
            for (int x = 0; x < (int)lengthX; x++)
            {
                var p = new Vector2(x, y) + start;
                var center = p + new Vector2(0.5f, 0.5f);
                float dist = (center - NearestPointStrict(from, to, center)).sqrMagnitude;
                if (dist > sqrRad2)
                {
                    continue;
                }
                dist = GaussFalloff(Mathf.Sqrt(dist), rad) * hardness;
                //dist = (samples[i]-pos).sqrMagnitude;
                Color c;
                if (dist > 0)
                {
                    c = Color.Lerp(pixels[y * (int)lengthX + x], col, dist);
                }
                else
                {
                    c = pixels[y * (int)lengthX + x];
                }

                pixels[y * (int)lengthX + x] = c;
            }
        }
        tex.SetPixels((int)start.x, (int)start.y, (int)lengthX, (int)lengthY, pixels, 0);

        return tex;
    }

  

    static void AddP(List<Vector2> tmpList, Vector2 p, float ix, float iy)
    {
        var x = p.x + ix;
        var y = p.y + iy;
        tmpList.Add(new Vector2(x, y));
    }

    static Vector2[] Sample(Vector2 p)
    {
        List<Vector2> tmpList = new List<Vector2>(32);

        switch (NumSamples)
        {
            case Samples.None:
                AddP(tmpList, p, 0.5f, 0.5f);
                break;

            case Samples.Samples2:
                AddP(tmpList, p, 0.25f, 0.5f);
                AddP(tmpList, p, 0.75f, 0.5f);
                break;

            case Samples.Samples4:
                AddP(tmpList, p, 0.25f, 0.5f);
                AddP(tmpList, p, 0.75f, 0.5f);
                AddP(tmpList, p, 0.5f, 0.25f);
                AddP(tmpList, p, 0.5f, 0.75f);
                break;

            case Samples.Samples8:
                AddP(tmpList, p, 0.25f, 0.5f);
                AddP(tmpList, p, 0.75f, 0.5f);
                AddP(tmpList, p, 0.5f, 0.25f);
                AddP(tmpList, p, 0.5f, 0.75f);

                AddP(tmpList, p, 0.25f, 0.25f);
                AddP(tmpList, p, 0.75f, 0.25f);
                AddP(tmpList, p, 0.25f, 0.75f);
                AddP(tmpList, p, 0.75f, 0.75f);
                break;
            case Samples.Samples16:
                AddP(tmpList, p, 0, 0);
                AddP(tmpList, p, 0.3f, 0);
                AddP(tmpList, p, 0.7f, 0);
                AddP(tmpList, p, 1, 0);

                AddP(tmpList, p, 0, 0.3f);
                AddP(tmpList, p, 0.3f, 0.3f);
                AddP(tmpList, p, 0.7f, 0.3f);
                AddP(tmpList, p, 1, 0.3f);

                AddP(tmpList, p, 0, 0.7f);
                AddP(tmpList, p, 0.3f, 0.7f);
                AddP(tmpList, p, 0.7f, 0.7f);
                AddP(tmpList, p, 1, 0.7f);

                AddP(tmpList, p, 0, 1);
                AddP(tmpList, p, 0.3f, 1);
                AddP(tmpList, p, 0.7f, 1);
                AddP(tmpList, p, 1, 1);
                break;

            case Samples.Samples32:
                AddP(tmpList, p, 0, 0);
                AddP(tmpList, p, 1, 0);
                AddP(tmpList, p, 0, 1);
                AddP(tmpList, p, 1, 1);

                AddP(tmpList, p, 0.2f, 0.2f);
                AddP(tmpList, p, 0.4f, 0.2f);
                AddP(tmpList, p, 0.6f, 0.2f);
                AddP(tmpList, p, 0.8f, 0.2f);

                AddP(tmpList, p, 0.2f, 0.4f);
                AddP(tmpList, p, 0.4f, 0.4f);
                AddP(tmpList, p, 0.6f, 0.4f);
                AddP(tmpList, p, 0.8f, 0.4f);

                AddP(tmpList, p, 0.2f, 0.6f);
                AddP(tmpList, p, 0.4f, 0.6f);
                AddP(tmpList, p, 0.6f, 0.6f);
                AddP(tmpList, p, 0.8f, 0.6f);

                AddP(tmpList, p, 0.2f, 0.8f);
                AddP(tmpList, p, 0.4f, 0.8f);
                AddP(tmpList, p, 0.6f, 0.8f);
                AddP(tmpList, p, 0.8f, 0.8f);

                AddP(tmpList, p, 0.5f, 0);
                AddP(tmpList, p, 0.5f, 1);
                AddP(tmpList, p, 0, 0.5f);
                AddP(tmpList, p, 1, 0.5f);

                AddP(tmpList, p, 0.5f, 0.5f);
                break;
            case Samples.RotatedDisc:
                AddP(tmpList, p, 0, 0);
                AddP(tmpList, p, 1, 0);
                AddP(tmpList, p, 0, 1);
                AddP(tmpList, p, 1, 1);

                Vector2 pq = new Vector2(p.x + 0.5f, p.y + 0.5f);
                AddP(tmpList, pq, 0.258f, 0.965f);//Sin (75°) && Cos (75°)
                AddP(tmpList, pq, -0.965f, -0.258f);
                AddP(tmpList, pq, 0.965f, 0.258f);
                AddP(tmpList, pq, 0.258f, -0.965f);
                break;
        }

        return tmpList.ToArray();
    }

    #endregion

    #region mathfx

    static float Hermite(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, value * value * (3.0f - 2.0f * value));
    }

    static float Sinerp(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, Mathf.Sin(value * Mathf.PI * 0.5f));
    }

    static float Coserp(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, 1.0f - Mathf.Cos(value * Mathf.PI * 0.5f));
    }

    static float Berp(float start, float end, float value)
    {
        value = Mathf.Clamp01(value);
        value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1 - value, 2.2f) + value) * (1 + (1.2f * (1 - value)));
        return start + (end - start) * value;
    }

    static float SmoothStep(float x, float min, float max)
    {
        x = Mathf.Clamp(x, min, max);
        var v1 = (x - min) / (max - min);
        var v2 = (x - min) / (max - min);
        return -2 * v1 * v1 * v1 + 3 * v2 * v2;
    }

    static float Lerp(float start, float end, float value)
    {
        return ((1.0f - value) * start) + (value * end);
    }

    static Vector3 NearestPoint(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
    {
        var lineDirection = Vector3.Normalize(lineEnd - lineStart);
        var closestPoint = Vector3.Dot((point - lineStart), lineDirection) / Vector3.Dot(lineDirection, lineDirection);
        return lineStart + (closestPoint * lineDirection);
    }

    static Vector3 NearestPointStrict(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
    {
        var fullDirection = lineEnd - lineStart;
        var lineDirection = Vector3.Normalize(fullDirection);
        var closestPoint = Vector3.Dot((point - lineStart), lineDirection) / Vector3.Dot(lineDirection, lineDirection);
        return lineStart + (Mathf.Clamp(closestPoint, 0.0f, Vector3.Magnitude(fullDirection)) * lineDirection);
    }

    static Vector2 NearestPointStrict(Vector2 lineStart, Vector2 lineEnd, Vector2 point)
    {
        var fullDirection = lineEnd - lineStart;
        var lineDirection = Normalize(fullDirection);
        var closestPoint = Vector2.Dot((point - lineStart), lineDirection) / Vector2.Dot(lineDirection, lineDirection);
        return lineStart + (Mathf.Clamp(closestPoint, 0.0f, fullDirection.magnitude) * lineDirection);
    }



    static float Bounce(float x)
    {
        return Mathf.Abs(Mathf.Sin(6.28f * (x + 1) * (x + 1)) * (1 - x));
    }

    // test for value that is near specified float (due to floating point inprecision)
    // all thanks to Opless for this!
    static bool Approx(float val, float about, float range)
    {
        return ((Mathf.Abs(val - about) < range));
    }

    // test if a Vector3 is close to another Vector3 (due to floating point inprecision)
    // compares the square of the distance to the square of the range as this 
    // avoids calculating a square root which is much slower than squaring the range
    static bool Approx(Vector3 val, Vector3 about, float range)
    {
        return ((val - about).sqrMagnitude < range * range);
    }
    static float GaussFalloff(float distance, float inRadius)
    {
        return Mathf.Clamp01(Mathf.Pow(360.0f, -Mathf.Pow(distance / inRadius, 2.5f) - 0.01f));
    }
    // CLerp - Circular Lerp - is like lerp but handles the wraparound from 0 to 360.
    // This is useful when interpolating eulerAngles and the object
    // crosses the 0/360 boundary.  The standard Lerp function causes the object
    // to rotate in the wrong direction and looks stupid. Clerp fixes that.
    static float Clerp(float start, float end, float value)
    {
        var min = 0.0f;
        var max = 360.0f;
        var half = Mathf.Abs((max - min) / 2.0f);//half the distance between min and max
        var retval = 0.0f;
        var diff = 0.0f;

        if ((end - start) < -half)
        {
            diff = ((max - start) + end) * value;
            retval = start + diff;
        }
        else if ((end - start) > half)
        {
            diff = -((max - end) + start) * value;
            retval = start + diff;
        }
        else retval = start + (end - start) * value;

        return retval;
    }


    //======= NEW =========//


    static Vector2 RotateVector(Vector2 vector, float rad)
    {
        rad *= Mathf.Deg2Rad;
        var res = new Vector2((vector.x * Mathf.Cos(rad)) - (vector.y * Mathf.Sin(rad)), (vector.x * Mathf.Sin(rad)) + (vector.y * Mathf.Cos(rad)));
        return res;
    }

    static Vector2 IntersectPoint(Vector2 start1, Vector2 start2, Vector2 dir1, Vector2 dir2)
    {
        if (dir1.x == dir2.x)
        {
            return Vector2.zero;
        }

        var h1 = dir1.y / dir1.x;
        var h2 = dir2.y / dir2.x;

        if (h1 == h2)
        {
            return Vector2.zero;
        }

        var line1 = new Vector2(h1, start1.y - start1.x * h1);
        var line2 = new Vector2(h2, start2.y - start2.x * h2);

        var y1 = line2.y - line1.y;
        var x1 = line1.x - line2.x;

        var x2 = y1 / x1;

        var y2 = line1.x * x2 + line1.y;
        return new Vector2(x2, y2);
    }

    static Vector2 ThreePointCircle(Vector2 a1, Vector2 a2, Vector2 a3)
    {
        var dir = a2 - a1;
        dir /= 2;
        var b1 = a1 + dir;
        dir = RotateVector(dir, 90);
        var l1 = dir;

        dir = a3 - a2;
        dir /= 2;
        var b2 = a2 + dir;
        dir = RotateVector(dir, 90);
        var l2 = dir;
        var p = IntersectPoint(b1, b2, l1, l2);
        return p;
    }

    //===== Bezier ====== //

    static Vector2 CubicBezier(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
    {
        // FIXME: fix bezier curve algorithm.
        /*	t = Mathf.Clamp01 (t);
            var t2 = 1-t;
            return Mathf.Pow(t2, 3) * p0 + 3 * Mathf.Pow(t2, 2) * t * p1 + 3 * t2 * Mathf.Pow(t, 2) * p2 + Mathf.Pow(t, 3) * p3;
         */
        return Vector2.zero;
    }

   

    //====== End Bezier ========//

    static Vector2 NearestPointOnCircle(Vector2 p, Vector2 center, float w)
    {
        Vector2 dir = p - center;
        dir = Normalize(dir);
        dir *= w;
        return center + dir;
    }
    static Vector2 Normalize(Vector2 p)
    {
        float mag = p.magnitude;
        return p / mag;
    }

    #endregion

};