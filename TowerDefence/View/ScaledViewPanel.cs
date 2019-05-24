using System.Drawing;
using System.Windows.Forms;
using TowerDefence.Controller;

namespace TowerDefence
{
    public class ScaledViewPanel : Panel
    {
        private readonly ScenePainter painter;
        private PointF centerLogicalPos;
        private bool dragInProgress;
        private Point dragStart;
        private PointF dragStartCenter;
        private PointF mouseLogicalPos;
        private float zoomScale;

        public ScaledViewPanel(ScenePainter painter)
            : this()
        {
            this.painter = painter;
            
        }

        public ScaledViewPanel()
        {
            
            FitToWindow = true;
            zoomScale = 1f;
        }

		

        public PointF CenterLogicalPos => centerLogicalPos;

        public float ZoomScale => zoomScale;

        public bool FitToWindow { get; }
        

        protected override void InitLayout()
        {
            base.InitLayout();
            ResizeRedraw = true;
            DoubleBuffered = true;
        }

        private PointF GetShift()
        {
            return new PointF(
                ClientSize.Width / 2f - CenterLogicalPos.X * ZoomScale,
                ClientSize.Height / 2f - CenterLogicalPos.Y * ZoomScale);
        }

        


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(Color.Black);
            if (painter == null) return;
            var sceneSize = painter.Size;
            if (FitToWindow)
            {
                var vMargin = sceneSize.Height * ClientSize.Width < ClientSize.Height * sceneSize.Width;
                zoomScale = vMargin
                    ? ClientSize.Width / sceneSize.Width
                    : ClientSize.Height / sceneSize.Height;
                centerLogicalPos = new PointF(sceneSize.Width / 2, sceneSize.Height / 2);
            }

            var shift = GetShift();
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(shift.X, shift.Y);
            e.Graphics.ScaleTransform(ZoomScale, ZoomScale);
            painter.Paint(e.Graphics);
        }
    }
}