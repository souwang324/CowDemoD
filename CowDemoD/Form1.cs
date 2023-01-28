using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Kitware.VTK;


namespace CowDemoD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.renderWindowControl = new Kitware.VTK.RenderWindowControl();
            this.renderWindowControl.AddTestActors = false;
            this.renderWindowControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderWindowControl.Location = new System.Drawing.Point(0, 0);
            this.renderWindowControl.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.renderWindowControl.Name = "renderWindowControl";
            this.renderWindowControl.Size = new System.Drawing.Size(617, 347);
            this.renderWindowControl.TabIndex = 0;
            this.renderWindowControl.TestText = null;
            this.renderWindowControl.Load += new System.EventHandler(this.VTKrenderWindowControl_Load);
            pictureBox1.Controls.Add(this.renderWindowControl);
        }


        public Kitware.VTK.RenderWindowControl renderWindowControl;

        private void VTKrenderWindowControl_Load(object sender, EventArgs e)
        {
            try
            {
                CowTransformTestFun();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK);
            }
        }

        private void CowTransformTestFun()
        {
            string strPath1 = "cow.vtp";

            vtkRenderWindow renWin = renderWindowControl.RenderWindow;
            vtkRenderer render = renWin.GetRenderers().GetFirstRenderer();

            vtkXMLPolyDataReader reader = vtkXMLPolyDataReader.New();
            reader.SetFileName(strPath1);
            reader.Update();

            vtkAxesActor axes01 = vtkAxesActor.New();
            double[] bounds = new double[6];
            bounds = reader.GetOutput().GetBounds();
            Debug.WriteLine(bounds[0] + " " + bounds[1] + " " + bounds[2] + " " + bounds[3] + " "
                + bounds[4] + " " + bounds[5] + " ");
            double[] axeLength = new double[3] { bounds[1] - bounds[0], bounds[3] - bounds[2], 2 * (bounds[5] - bounds[4]) };

            double beta = 225;
            IntPtr paxeLength = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * 3);
            Marshal.Copy(axeLength, 0, paxeLength, 3);
            axes01.SetTotalLength(paxeLength);
            Marshal.FreeHGlobal(paxeLength);

            vtkPolyDataMapper mapper01 = vtkPolyDataMapper.New();
            mapper01.SetInputConnection(reader.GetOutputPort());
            double[] origin = new double[4] { -(bounds[1] - bounds[0]) / 2 - 5, 0, 0, 0 };
            IntPtr porigin01 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * 3);
            Marshal.Copy(origin, 0, porigin01, 3);

            vtkActor actor00 = vtkActor.New();
            actor00.SetMapper(mapper01);

            vtkActor actor01 = vtkActor.New();
            vtkTransform myTrans01 = vtkTransform.New();
            double alpha = -60;
            myTrans01.RotateX(beta);
            myTrans01.RotateZ(alpha);
            myTrans01.Update();
            double[] origin01t = myTrans01.GetMatrix().MultiplyDoublePoint(porigin01);
            vtkTransform myTrans01_ = vtkTransform.New();
            myTrans01_.Translate(origin01t[0], origin01t[1], origin01t[2]);
            myTrans01_.RotateX(beta);
            myTrans01_.RotateZ(alpha);
            myTrans01_.Update();
            actor01.SetMapper(mapper01);
            actor01.SetUserMatrix(myTrans01_.GetMatrix());


            vtkActor actor02 = vtkActor.New();
            vtkTransform myTrans02 = vtkTransform.New();
            myTrans02.RotateX(beta);
            myTrans02.RotateY(60);
            myTrans02.RotateZ(alpha);
            myTrans02.Update();
            double[] origin02t = myTrans02.GetMatrix().MultiplyDoublePoint(porigin01);
            vtkTransform myTrans02_ = vtkTransform.New();
            myTrans02_.Translate(origin02t[0], origin02t[1], origin02t[2]);
            myTrans02_.RotateX(beta);
            myTrans02_.RotateY(60);
            myTrans02_.RotateZ(alpha);
            myTrans02_.Update();
            actor02.SetMapper(mapper01);
            actor02.SetUserMatrix(myTrans02_.GetMatrix());

            vtkActor actor03 = vtkActor.New();
            vtkTransform myTrans03 = vtkTransform.New();
            myTrans03.RotateX(beta);
            myTrans03.RotateY(120);
            myTrans03.RotateZ(alpha);
            myTrans03.Update();
            double[] origin03t = myTrans03.GetMatrix().MultiplyDoublePoint(porigin01);
            vtkTransform myTrans03_ = vtkTransform.New();
            myTrans03_.Translate(origin03t[0], origin03t[1], origin03t[2]);
            myTrans03_.RotateX(beta);
            myTrans03_.RotateY(120);
            myTrans03_.RotateZ(alpha);
            myTrans03_.Update();
            actor03.SetMapper(mapper01);
            actor03.SetUserMatrix(myTrans03_.GetMatrix());

            vtkActor actor04 = vtkActor.New();
            vtkTransform myTrans04 = vtkTransform.New();
            myTrans04.RotateX(beta);
            myTrans04.RotateY(180);
            myTrans04.RotateZ(alpha);
            myTrans04.Update();
            double[] origin04t = myTrans04.GetMatrix().MultiplyDoublePoint(porigin01);
            vtkTransform myTrans04_ = vtkTransform.New();
            myTrans04_.Translate(origin04t[0], origin04t[1], origin04t[2]);
            myTrans04_.RotateX(beta);
            myTrans04_.RotateY(180);
            myTrans04_.RotateZ(alpha);
            myTrans04_.Update();
            actor04.SetMapper(mapper01);
            actor04.SetUserMatrix(myTrans04_.GetMatrix());

            vtkActor actor05 = vtkActor.New();
            vtkTransform myTrans05 = vtkTransform.New();
            myTrans05.RotateX(beta);
            myTrans05.RotateY(-120);
            myTrans05.RotateZ(alpha);
            myTrans05.Update();
            double[] origin05t = myTrans05.GetMatrix().MultiplyDoublePoint(porigin01);
            vtkTransform myTrans05_ = vtkTransform.New();
            myTrans05_.Translate(origin05t[0], origin05t[1], origin05t[2]);
            myTrans05_.RotateX(beta);
            myTrans05_.RotateY(-120);
            myTrans05_.RotateZ(alpha);
            myTrans05_.Update();
            actor05.SetMapper(mapper01);
            actor05.SetUserMatrix(myTrans05_.GetMatrix());

            vtkActor actor06 = vtkActor.New();
            vtkTransform myTrans06 = vtkTransform.New();
            myTrans06.RotateX(beta);
            myTrans06.RotateY(-60);
            myTrans06.RotateZ(alpha);
            myTrans06.Update();
            double[] origin06t = myTrans06.GetMatrix().MultiplyDoublePoint(porigin01);
            vtkTransform myTrans06_ = vtkTransform.New();
            myTrans06_.Translate(origin06t[0], origin06t[1], origin06t[2]);
            myTrans06_.RotateX(beta);
            myTrans06_.RotateY(-60);
            myTrans06_.RotateZ(alpha);
            myTrans06_.Update();
            actor06.SetMapper(mapper01);
            actor06.SetUserMatrix(myTrans06_.GetMatrix());

            Marshal.FreeHGlobal(porigin01);
            render.AddActor(axes01);
            //render.AddActor(actor00);
            render.AddActor(actor01);
            render.AddActor(actor02);
            render.AddActor(actor03);
            render.AddActor(actor04);
            render.AddActor(actor05);
            render.AddActor(actor06);
            render.SetBackground(0.2, 0.3, 0.4);

            renWin.AddRenderer(render);
            renWin.SetWindowName("Cow");

            renWin.Render();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

