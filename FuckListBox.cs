// Decompiled with JetBrains decompiler
// Type: UnrealIccupBruteforcer.FuckListBox
// Assembly: UnrealIccupBruteforcer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6E7BBA8-DFA2-4C69-A36D-873EA3E30432
// Assembly location: C:\Users\Karaulov\AppData\Roaming\Skype\My Skype Received Files\Brute[goshanvartanov].exe

using UnrealIccupBruteforcer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UnrealIccupBruteforcer
{
    public class FuckListBox : ListBox
    {
        public Image image;
        public Brush brush;
        public Brush selectedBrush;
        public IContainer components;

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            Invalidate();
            base.OnSelectedIndexChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, new Point(-15, -10));
            if (Focused && SelectedItem != null)
            {
                Rectangle itemRectangle = GetItemRectangle(SelectedIndex);
                e.Graphics.FillRectangle(Brushes.Transparent, itemRectangle);
            }
            int index = 0;
            while (index < Items.Count)
            {
                e.Graphics.DrawString(GetItemText(Items[index]), Font, (Brush)new SolidBrush(ForeColor), (RectangleF)GetItemRectangle(index), new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
                 { ++index; }
            }
            base.OnPaint(e);
        }

        public FuckListBox()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.ContainerControl | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.Transparent;
            DrawMode = DrawMode.OwnerDrawVariable;
            image = (Image)AllResources.LogBox;
            brush = (Brush)new SolidBrush(Color.Black);
            selectedBrush = (Brush)new SolidBrush(Color.White);
        }

        public void ListBoxWithBg_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                if (e.Index == (Items.Count - 1))
                    e.Graphics.DrawImage(image, new Point(0, 0));
                else
                    e.Graphics.DrawImage(image, e.Bounds, e.Bounds, GraphicsUnit.Pixel);
                Brush brush = (e.State & DrawItemState.Selected) == DrawItemState.Selected ? selectedBrush : this.brush;
                e.Graphics.DrawString(Items[e.Index].ToString(), Font, brush, (RectangleF)e.Bounds);
            }
            catch
            {
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        public void InitializeComponent()
        {
            SuspendLayout();
            Size = new Size(307, 139);
            ResumeLayout(false);
        }
    }
}
