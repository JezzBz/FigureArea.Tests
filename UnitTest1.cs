using FigureArea.Exceptions;
using FigureArea.Interfaces;
using FigureArea.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FigureArea.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(FigureNotExistException))]
        public void Create_UnValide_Triangle_NotExsist_Test()
        {

            Triangle triangle = new Triangle(new int[] { 1, 5, 8 });

        }

       
        [TestMethod]
        [ExpectedException(typeof(FigureNotExistException))]
        public void Create_UnValide_Triangle_Negative_Test()
        { 
      
            Triangle triangle = new Triangle(new int[] { -1, -5, -8 });
           
        }

        [TestMethod]
        [ExpectedException(typeof(FigureNotExistException))]
        public void Create_UnValide_Triangle__Test()
        {

            Triangle triangle = new Triangle(new int[] { 1,2 });

        }

        [TestMethod]
        [ExpectedException(typeof(FigureNotExistException))]
        public void Create_UnValide_Triangle_Zeroes_Test()
        {

            Triangle triangle = new Triangle(new int[] { 0,0,0 });

        }

        [TestMethod]
        [ExpectedException(typeof(FigureNotExistException))]
        public void Create_UnValide_Triangle_Empty_Test()
        {

            Triangle triangle = new Triangle(new int[] { });

        }

        [TestMethod]
        [ExpectedException(typeof(FigureNotExistException))]
        public void Create_UnValide_Triangle_Null_Test()
        {

            Triangle triangle = new Triangle(null);

        }

        [TestMethod]
        public void Create_Valide_Triangle__Test()
        {

            Triangle triangle = new Triangle(new int[] { 6,12,13 });
            

        }

        [TestMethod]
       
        public void IsRectangular_Valide_Triangle_Test()
        {

            Triangle triangle = new Triangle(new int[] {6,8,10});
            bool istrue = true;
            Assert.AreEqual(triangle.IsRectangular(), istrue);

        }
        
        [TestMethod]
        public void IsRectangular_UnValide_Triangle_Test()
        {

            Triangle triangle = new Triangle(new int[] { 6, 12, 13 });
            bool isfalse = false;
            Assert.AreEqual(triangle.IsRectangular(), isfalse);

        }
      
        [TestMethod]
        public void GetArea_Valide_Triangle_Test()
        {

            Triangle triangle = new Triangle(new int[] { 6, 12, 13 });
            double result=triangle.GetArea();
            Assert.AreEqual(35.895, result, 0.01);

        }

        [TestMethod]
        public void GetArea_Valide_Ñircle_Test()
        {

            Circle circle = new Circle(12);
            double result = circle.GetArea();
            Assert.AreEqual(452.389, result, 0.01);

        }
        [TestMethod]
        public void Valide_UnkownFigure_Test()
        {

            Circle circle = new Circle(12);
            Figure figure = new Figure();
            ///TODO:implement a shape type request
            double result = figure.GetArea(circle); 
            Assert.AreEqual(452.389, result, 0.01);

        }
        //Create new Figure test(so easy)
        private class Rhombus : IFigure
        {
            int Side { get; set; }
            int Height { get; set; }
            public Rhombus(int side, int h)
            {
                if (ISExist(side, h))
                {
                    Side = side;
                    Height = h;
                }
                else throw new FigureNotExistException();
            }
            public double GetArea()
            {

                return (double)Side*Height;
            }

            protected bool ISExist(int h, int side)
            {
                if (side > 0 && h > 0)
                {
                    return true;
                }
                return false;
            }




        }
        [TestMethod]
        public void Create_NewUnkownFigure_Test()
        {
            Figure figure = new Figure();
            IFigure rhombus = new Rhombus(1, 2);

            Assert.AreEqual(2, figure.GetArea(rhombus));

        }
     
    }
}
