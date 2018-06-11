﻿using Lab3.Drawers;
using Lab3.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Lab3.Images
{
    public class Image
    {
        public List<AngularShape> Shapes;

        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }


        public void Move(float x, float y)
        {
            if (Shapes is null)
                return;

            foreach (var shape in Shapes)
            {
                if (shape is ITwoDimensionalShape)
                    shape.Move(shape.OffsetX + x, shape.OffsetY + y, shape.OffsetZ);
                if (shape is IThreeDimensionalShape)
                    shape.Move(0, shape.OffsetY +  x, shape.OffsetZ - y);
            }

            X = x;
            Y = y;
        }

        public Image()
        {
            Shapes = new List<AngularShape>();
        }

        public Image(float length, float width)
        {
            Length = length;
            Width = width;
            Shapes = new List<AngularShape>();
        }

        public void AddShape(AngularShape shape)
        {
            Shapes.Add(shape);
        }

        public void MoveShape(AngularShape shape, float x, float y)
        {
            shape.Move(shape.OffsetX + x, shape.OffsetY + y, shape.OffsetZ);
        }

        public void Scale(float fraction)
        {
            foreach (var shape in Shapes)
            {
                shape.Scale(fraction);
            }

            Width = Width * fraction;
            Length = Length * fraction;
        }
    }
}
