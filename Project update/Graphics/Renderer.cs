using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

//include GLM Library


namespace Graphics
{
    class Renderer
    {
        Shader sh;
        uint vertexBufferID;
        uint IndexBufferID;
        public void Initialize()
        {

            // Declare the two shaders files to the OpenGl
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            sh = new Shader(projectPath + "\\Shaders\\SimpleVertexShader.vertexshader",    // shader of draw positions of geometeric object.
                projectPath + "\\Shaders\\SimpleFragmentShader.fragmentshader");           // shader of filling colors pf geometeric object.

            // Determine the background Color of the shaders.
            //(Red,Green,Blue,Transparent"shadow")       
            // minimize the float point to dark
            // maximize the float point to light
            Gl.glClearColor(1, 1, 1, 1);

            //initialize vertex to draw the primitives 
            float[] verts = { 
		
		        // 1-  1	  point index
		        //-----
                -0.17f, 0.72f, 0.0f,  //0       a
                 0,0,0,
                -0.30f, 0.54f, 0.0f,
                 0,0,0,
                -0.09f, 0.54f, 0.0f,
                 0,0,0,

		        // 2 - 2
		        //----------
		         0.06f, 0.78f, 0.0f,  //3       a
                 0,0,0,
                -0.17f, 0.54f, 0.0f ,
                 0,0,0,
                 0.08f, 0.54f, 0.0f,
                 0,0,0,

                //24
                -0.40f, 0.37f, 0.0f ,  //6
                 0.8f,0.4f,0.2f,
                -0.66f, 0.17f, 0.0f,
                 0.8f,0.4f,0.2f,
                 0.01f, 0.27f,0.0f,
                 0.2f,0.2f,0.2f,
                // 3
		        -0.30f, 0.54f, 0.0f,  //9       b
                 0.1f,0.1f,0.1f,
                -0.45f, 0.36f, 0.0f,
                 0.1f,0.1f,0.1f,
                -0.17f, 0.30f, 0.0f,
                 0.15f,0.15f,0.15f,
			
		        // 4
		        -0.17f, 0.30f, 0.0f,    //12     b
                 0.15f,0.15f,0.15f,
                -0.30f, 0.54f, 0.0f,
                 0.1f,0.1f,0.1f,
                 0.08f, 0.54f, 0.0f,
                 0.1f,0.1f,0.1f,

                // 5
                 0.08f, 0.54f, 0.0f, //15       b
                 0.1f,0.1f,0.1f,
                -0.06f, 0.41f,0.0f,
                 0.15f,0.15f,0.15f,
                 0.35f, 0.41f,0.0f,
                 0.15f,0.15f,0.15f,

                 // 6
		        -0.27f, 0.32f, 0.0f,  //18       eye
                 0.1f,0.1f,1f,
                -0.20f, 0.35f, 0.0f,
                 0.1f,0.1f,1f,
                -0.17f, 0.30f, 0.0f,
                 0.1f,0.1f,1f,
                
                // 7
                -0.06f, 0.41f, 0.0f,  //21      c
                 0.2f,0.2f,0.2f,
                -0.17f, 0.30f, 0.0f,
                 0.2f,0.2f,0.2f,
                 0.23f, 0.41f, 0.0f,
                 0.2f,0.2f,0.2f,

                //8
                 0.02f, 0.24f, 0.0f,  //24      d
                 0.25f,0.25f,0.25f,
                -0.17f, 0.30f, 0.0f,
                 0.25f,0.25f,0.25f,
                 0.23f, 0.41f, 0.0f,
                 0.25f,0.25f,0.25f,

                //9
                 0.23f, 0.41f, 0.0f,  //27      e
                 0.3f,0.3f,0.3f,
                 0.02f, 0.24f,0.0f,
                 0.3f,0.3f,0.3f,
                 0.62f, -0.01f,0.0f,
                 0.4f,0.4f,0.4f,

                //10
                 0.02f, 0.24f ,0.0f,  //30
                 0.3f,0.3f,0.3f,
                 0.24f, -0.10f,0.0f,
                 0.35f,0.35f,0.35f,
                 0.5f, 0.04f ,0.0f,
                 0.4f,0.4f,0.4f,

                //11
                 0.24f, -0.10f,0.0f,  //33
                 0.35f,0.35f,0.35f,
                 0.5f, 0.04f ,0.0f,
                 0.4f,0.4f,0.4f,
                 0.70f, -0.44f, 0.0f,
                 0.5f,0.5f,0.5f,

                //12
                 0.24f, -0.10f,0.0f,  //36
                 0.35f,0.35f,0.35f,
                 0.32f, -0.30f,0.0f,
                 0.35f,0.35f,0.35f,
                 0.59f, -0.35f,0.0f,
                 0.5f,0.5f,0.5f,

                //13
                 0.32f, -0.30f, 0.0f, //39
                 0.35f,0.35f,0.35f,
                 0.59f, -0.35f, 0.0f,
                 0.5f,0.5f,0.5f,
                 0.49f, -0.55f, 0.0f,
                 0.5f,0.5f,0.5f,

                //14
                 0.32f, -0.30f, 0.0f, //42
                 0.35f,0.35f,0.35f,
                 0.07f, -0.49f, 0.0f,
                 0.35f,0.35f,0.35f,
                 0.44f, -0.47f, 0.0f,
                 0.4f,0.4f,0.4f,

                
                //15
                 0.08f, -0.69f,0.0f,  //45
                 0.5f,0.5f,0.5f,
                 0.07f, -0.49f,0.0f,
                 0.35f,0.35f,0.35f,
                 0.41f, -0.47f,0.0f,
                 0.35f,0.35f,0.35f,
                 
                //18
                -0.30f, -0.81f, 0.0f,    //48
                 0.5f,0.5f,0.5f,
                -0.18f, -0.45f, 0.0f,
                 0.4f,0.4f,0.4f,
                 0.07f, -0.49f, 0.0f,
                 0.4f,0.4f,0.4f,
                
                //19
                -0.42f, -0.62f, 0.0f,   //51
                 0.5f,0.5f,0.5f,
                -0.37f, -0.44f, 0.0f,
                 0.4f,0.4f,0.4f,
                -0.18f, -0.45f, 0.0f,
                 0.4f,0.4f,0.4f,
                 
                //16,20
                -0.17f, -0.06f, 0.0f,   //54
                 0.35f,0.35f,0.35f,
                -0.46f, -0.44f, 0.0f,
                 0.4f,0.4f,0.4f,
                 0.07f, -0.49f,0.0f,
                 0.4f,0.4f,0.4f,

                // 17 - 14 - 13 -12
                 0.24f, -0.07f, 0.0f,   //57
                 0.3f,0.3f,0.3f,
                 0.07f, -0.49f,0.0f,
                 0.35f,0.35f,0.35f,
                 0.32f, -0.30f, 0.0f,
                 0.35f,0.35f,0.35f,
                 
                //27
                -0.22f,  0.04f, 0.0f,  //60
                 0.3f,0.3f,0.3f,
                -0.17f, -0.06f, 0.0f,
                 0.3f,0.3f,0.3f,
                 0.24f, -0.07f, 0.0f,
                 0.3f,0.3f,0.3f,

                //17
                 0.07f, -0.49f,0.0f,    //63
                 0.4f,0.4f,0.4f,
                -0.17f, -0.06f, 0.0f,
                 0.35f,0.35f,0.35f,
                 0.24f, -0.07f, 0.0f,
                 0.35f,0.35f,0.35f,         

                //21
                -0.17f, 0.03f, 0.0f, //66
                 0.2f,0.2f,0.2f,
                -0.73f, 0.10f, 0.0f,
                 0.2f,0.2f,0.2f,
                -0.63f, 0.02f, 0.0f,
                 0.1f,0.1f,0.1f,

                //21.5
                -0.73f, 0.10f, 0.0f,   //69
                 0.1f,0.1f,0.1f,
                -0.66f, 0.18f, 0.0f,
                 0.2f,0.2f,0.2f,
                -0.56f, 0.07f, 0.0f,
                 0.1f,0.1f,0.1f,

                //21.7
                -0.56f, 0.07f, 0.0f,   //72
                 0.1f,0.1f,0.1f,
                -0.66f, 0.18f, 0.0f,
                 0.2f,0.2f,0.2f,
                -0.45f, 0.21f, 0.0f,
                 0.2f,0.2f,0.2f,

                //22
                -0.56f, 0.07f, 0.0f,   //75
                 0.1f,0.1f,0.1f,
                -0.45f, 0.21f, 0.0f,
                 0.2f,0.2f,0.2f,
                -0.17f, 0.03f, 0.0f,
                 0.1f,0.1f,0.1f,

                //23
                -0.05f, 0.265f,0.0f,     //78
                 0.2f,0.2f,0.2f,
                -0.45f, 0.21f, 0.0f,
                 0.2f,0.2f,0.2f,
                -0.17f, 0.03f,0.0f,
                 0.1f,0.1f,0.1f,

                //23 --- 
                -0.05f, 0.265f,0.0f,     //78
                 0.3f,0.3f,0.3f,
                 0.025f, 0.24f, 0.0f,
                 0.3f,0.3f,0.3f,
                -0.17f, 0.03f,0.0f,
                 0.1f,0.1f,0.1f,

                 //22.5
                 0.025f, 0.24f, 0.0f,   //81
                  0.3f,0.3f,0.3f,
                 -0.18f, 0.028f,0.0f,
                  0.1f,0.1f,0.1f,
                  0.24f, -0.08f,0.0f,
                  0.3f,0.3f,0.3f,
           
                 //25
                 -0.42f, 0.35f, 0.0f ,  //84
                  0.8f,0.3f,0f,
                 -0.60f, 0.25f, 0.0f,
                  0.8f,0.3f,0f,
                 -0.675f, 0.158f, 0.0f,
                  0.8f,0.3f,0f,

                 //26
                 -0.75f, 0.20f,0.0f,    //87  nose
                  0,0,0,
                 -0.60f, 0.25f, 0.0f,
                  0,0,0,
                 -0.71f, 0.11f, 0.0f,
                  0,0,0,

            };

            // ID is refernece to the vertex buffer of points 
            vertexBufferID = GPU.GenerateBuffer(verts);

            ushort[] indices = { 0, 1, 2, 1, 2, 3 };
            IndexBufferID = GPU.GenerateElementBuffer(indices);
        }

        public void Draw()
        {

            // Determine the background Color of the Buffer.
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            // call the vertex and fragement shader that will be used
            sh.UseShader();

            // enable vertex attributes using pointer(0)
            Gl.glEnableVertexAttribArray(0);
            Gl.glEnableVertexAttribArray(1);

            // convert the array to the vertex points (x,y,z)
            //describe vertex attributes (index, size, arrayType, normalized, stride, offset)
            Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, sizeof(float) * 6, IntPtr.Zero);
            Gl.glVertexAttribPointer(1, 3, Gl.GL_FLOAT, Gl.GL_FALSE, sizeof(float) * 6, (IntPtr)(sizeof(float) * 3));

            //// Draw your primitives !

            //// 1-  Eyes        
            //Gl.glPointSize(5);
            //Gl.glDrawArrays(Gl.GL_POINTS,0,2);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 3, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 6, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 9, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 12, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 15, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 18, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 21, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 24, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 27, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 30, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 33, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 36, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 39, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 42, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 45, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 48, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 51, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 54, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 57, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 60, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 63, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 66, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 69, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 72, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 75, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 78, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 81, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 84, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 87, 3);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 90, 3);


            //disable vertex attributes to the pointer(0)
            Gl.glDisableVertexAttribArray(0);
            Gl.glDisableVertexAttribArray(1);
        }

        public void Update()
        {

        }

        public void CleanUp()
        {
            sh.DestroyShader();
        }
    }
}
