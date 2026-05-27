using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.Matrices;

namespace StarThrower.Matrices.Test
{
    [TestClass]
    public class MatrixTest
    {
        #region [ 1-D Matrix ]

        [TestMethod]
        public void Matrix1DCtor()
        {
            List<int> indices = new List<int>();
            indices.Add(1);
            indices.Add(2);
            indices.Add(3);
            Matrix<int, int> md1 = new Matrix<int, int>(indices);

            Assert.AreEqual(true, (md1 != null));
        }

        [TestMethod]
        public void Matrix1DGetter()
        {
            List<int> indices = new List<int>();
            indices.Add(1);
            indices.Add(2);
            indices.Add(3);
            Matrix<int, int> md1 = new Matrix<int, int>(indices);

            Assert.AreEqual(0, md1[1]);
            Assert.AreEqual(0, md1[2]);
            Assert.AreEqual(0, md1[3]);
        }

        [TestMethod]
        public void Matrix1DGetter2()
        {
            Guid i1 = Guid.NewGuid();
            Guid i2 = Guid.NewGuid();
            Guid i3 = Guid.NewGuid();
            List<Guid> indices = new List<Guid>();
            indices.Add(i1);
            indices.Add(i2);
            indices.Add(i3);
            Matrix<Guid, int> md1 = new Matrix<Guid, int>(indices);

            Assert.AreEqual(0, md1.GetItemAt(0));
            Assert.AreEqual(0, md1.GetItemAt(1));
            Assert.AreEqual(0, md1.GetItemAt(2));
        }

        [TestMethod]
        public void Matrix1DSetter()
        {
            List<int> indices = new List<int>();
            indices.Add(1);
            indices.Add(2);
            indices.Add(3);
            Matrix<int, int> md1 = new Matrix<int, int>(indices);
            md1[1] = 4;
            md1[2] = 5;
            md1[3] = 6;

            Assert.AreEqual(4, md1[1]);
            Assert.AreEqual(5, md1[2]);
            Assert.AreEqual(6, md1[3]);
        }

        [TestMethod]
        public void Matrix1DSetter2()
        {
            List<int> indices = new List<int>();
            indices.Add(1);
            indices.Add(2);
            indices.Add(3);
            Matrix<int, int> md1 = new Matrix<int, int>(indices);
            md1.SetItemAt(4, 0);
            md1.SetItemAt(5, 1);
            md1.SetItemAt(6, 2);

            Assert.AreEqual(4, md1.GetItemAt(0));
            Assert.AreEqual(5, md1.GetItemAt(1));
            Assert.AreEqual(6, md1.GetItemAt(2));
        }

        [TestMethod]
        public void Matrix1DGetIndexesAt01()
        {
            int x1 = 1;
            int x2 = 2;
            int x3 = 3;

            List<int> indices = new List<int>();
            indices.Add(x1);
            indices.Add(x2);
            indices.Add(x3);
            Matrix<int, int> m = new Matrix<int, int>(indices);

            Assert.AreEqual(x1, m.GetIndexesAt(0)[0]);
            Assert.AreEqual(x2, m.GetIndexesAt(1)[0]);
            Assert.AreEqual(x3, m.GetIndexesAt(2)[0]);
        }

        [TestMethod]
        public void Matrix1DGetIndexesAt02()
        {
            Guid x1 = new Guid("{CB17883B-C9A5-4D6E-8E01-020F384D6E61}");
            Guid x2 = new Guid("{84B6F06C-54EC-4A5C-990E-14A64224C703}");
            Guid x3 = new Guid("{D1749384-9ED5-401D-9E7F-DDF41B90A894}");

            List<Guid> indices = new List<Guid>();
            indices.Add(x1);
            indices.Add(x2);
            indices.Add(x3);
            Matrix<Guid, int> m = new Matrix<Guid, int>(indices);

            Assert.AreEqual(x1, m.GetIndexesAt(0)[0]);
            Assert.AreEqual(x2, m.GetIndexesAt(1)[0]);
            Assert.AreEqual(x3, m.GetIndexesAt(2)[0]);
        }

        #endregion


        #region [ 2-D Matrix ]

        [TestMethod]
        public void Matrix2DCtor()
        {
            List<int> d1indices = new List<int>();
            d1indices.Add(1);
            d1indices.Add(2);
            d1indices.Add(3);

            List<int> d2indices = new List<int>();
            d2indices.Add(1);
            d2indices.Add(2);
            d2indices.Add(3);

            Matrix<int, int> md2 = new Matrix<int, int>(d1indices, d2indices);

            Assert.AreEqual(0, md2[1, 1]);
            Assert.AreEqual(0, md2[1, 2]);
            Assert.AreEqual(0, md2[1, 3]);

            Assert.AreEqual(0, md2[2, 1]);
            Assert.AreEqual(0, md2[2, 2]);
            Assert.AreEqual(0, md2[2, 3]);

            Assert.AreEqual(0, md2[3, 1]);
            Assert.AreEqual(0, md2[3, 2]);
            Assert.AreEqual(0, md2[3, 3]);
        }

        [TestMethod]
        public void Matrix2DSetter()
        {
            List<int> d1indices = new List<int>();
            d1indices.Add(1);
            d1indices.Add(2);
            d1indices.Add(3);

            List<int> d2indices = new List<int>();
            d2indices.Add(1);
            d2indices.Add(2);
            d2indices.Add(3);

            Matrix<int, int> md2 = new Matrix<int, int>(d1indices, d2indices);


            md2[1, 1] = 1;
            md2[1, 2] = 2;
            md2[1, 3] = 3;
            md2[2, 1] = 4;
            md2[2, 2] = 5;
            md2[2, 3] = 6;
            md2[3, 1] = 7;
            md2[3, 2] = 8;
            md2[3, 3] = 9;


            Assert.AreEqual(1, md2[1, 1]);
            Assert.AreEqual(2, md2[1, 2]);
            Assert.AreEqual(3, md2[1, 3]);
            Assert.AreEqual(4, md2[2, 1]);
            Assert.AreEqual(5, md2[2, 2]);
            Assert.AreEqual(6, md2[2, 3]);
            Assert.AreEqual(7, md2[3, 1]);
            Assert.AreEqual(8, md2[3, 2]);
            Assert.AreEqual(9, md2[3, 3]);
        }

        [TestMethod]
        public void Matrix2DSetter2()
        {
            List<int> d1indices = new List<int>();
            d1indices.Add(1);
            d1indices.Add(2);
            d1indices.Add(3);

            List<int> d2indices = new List<int>();
            d2indices.Add(1);
            d2indices.Add(2);
            d2indices.Add(3);

            Matrix<int, int> md2 = new Matrix<int, int>(d1indices, d2indices);


            md2.SetItemAt(1, 0, 0);
            md2.SetItemAt(2, 0, 1);
            md2.SetItemAt(3, 0, 2);
            md2.SetItemAt(4, 1, 0);
            md2.SetItemAt(5, 1, 1);
            md2.SetItemAt(6, 1, 2);
            md2.SetItemAt(7, 2, 0);
            md2.SetItemAt(8, 2, 1);
            md2.SetItemAt(9, 2, 2);


            Assert.AreEqual(1, md2.GetItemAt(0, 0));
            Assert.AreEqual(2, md2.GetItemAt(0, 1));
            Assert.AreEqual(3, md2.GetItemAt(0, 2));
            Assert.AreEqual(4, md2.GetItemAt(1, 0));
            Assert.AreEqual(5, md2.GetItemAt(1, 1));
            Assert.AreEqual(6, md2.GetItemAt(1, 2));
            Assert.AreEqual(7, md2.GetItemAt(2, 0));
            Assert.AreEqual(8, md2.GetItemAt(2, 1));
            Assert.AreEqual(9, md2.GetItemAt(2, 2));
        }

        [TestMethod]
        public void Matrix2DGetIndexesAt01()
        {
            int x1 = 1;
            int x2 = 2;
            int x3 = 3;

            int y1 = 1;
            int y2 = 2;
            int y3 = 3;

            List<int> xIndices = new List<int>();
            xIndices.Add(x1);
            xIndices.Add(x2);
            xIndices.Add(x3);

            List<int> yIndices = new List<int>();
            yIndices.Add(y1);
            yIndices.Add(y2);
            yIndices.Add(y3);

            Matrix<int, int> m = new Matrix<int, int>(xIndices, yIndices);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 0)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(0, 0)[1]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 1)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(0, 1)[1]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 2)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(0, 2)[1]);


            Assert.AreEqual(x2, m.GetIndexesAt(1, 0)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(0, 0)[1]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 1)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(1, 1)[1]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 2)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(2, 2)[1]);


            Assert.AreEqual(x3, m.GetIndexesAt(2, 0)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(0, 0)[1]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 1)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(1, 1)[1]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 2)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(2, 2)[1]);
        }

        [TestMethod]
        public void Matrix2DGetIndexesAt02()
        {
            Guid x1 = new Guid("{917F34FC-37BD-4660-80BB-FA9641EDA9FF}");
            Guid x2 = new Guid("{F577DD17-4D22-4316-80A9-0AA282BF2276}");
            Guid x3 = new Guid("{377E5A0A-E86D-4FA2-86EA-BD439CD6BD30}");

            Guid y1 = new Guid("{9E419CEC-03F5-4D27-ACD3-1644EABFBFB6}");
            Guid y2 = new Guid("{3C797349-96F1-4D78-8201-8704ED6C2FEA}");
            Guid y3 = new Guid("{58907862-E6DD-41B0-A79C-25C695D2D54E}");

            List<Guid> xIndices = new List<Guid>();
            xIndices.Add(x1);
            xIndices.Add(x2);
            xIndices.Add(x3);

            List<Guid> yIndices = new List<Guid>();
            yIndices.Add(y1);
            yIndices.Add(y2);
            yIndices.Add(y3);

            Matrix<Guid, int> m = new Matrix<Guid, int>(xIndices, yIndices);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 0)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(0, 0)[1]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 1)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(0, 1)[1]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 2)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(0, 2)[1]);


            Assert.AreEqual(x2, m.GetIndexesAt(1, 0)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(0, 0)[1]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 1)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(1, 1)[1]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 2)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(2, 2)[1]);


            Assert.AreEqual(x3, m.GetIndexesAt(2, 0)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(0, 0)[1]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 1)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(1, 1)[1]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 2)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(2, 2)[1]);
        }

        #endregion


        #region [ 3-D Matrix ]

        [TestMethod]
        public void Matrix3DCtor()
        {
            List<int> d1indices = new List<int>();
            d1indices.Add(1);
            d1indices.Add(2);
            d1indices.Add(3);

            List<int> d2indices = new List<int>();
            d2indices.Add(1);
            d2indices.Add(2);
            d2indices.Add(3);

            List<int> d3indices = new List<int>();
            d3indices.Add(1);
            d3indices.Add(2);
            d3indices.Add(3);

            Matrix<int, int> md2 = new Matrix<int, int>(d1indices, d2indices, d3indices);

            Assert.AreEqual(0, md2[1, 1, 1]);
            Assert.AreEqual(0, md2[1, 1, 2]);
            Assert.AreEqual(0, md2[1, 1, 3]);

            Assert.AreEqual(0, md2[1, 2, 1]);
            Assert.AreEqual(0, md2[1, 2, 2]);
            Assert.AreEqual(0, md2[1, 2, 3]);

            Assert.AreEqual(0, md2[1, 3, 1]);
            Assert.AreEqual(0, md2[1, 3, 2]);
            Assert.AreEqual(0, md2[1, 3, 3]);


            Assert.AreEqual(0, md2[2, 1, 1]);
            Assert.AreEqual(0, md2[2, 1, 2]);
            Assert.AreEqual(0, md2[2, 1, 3]);

            Assert.AreEqual(0, md2[2, 2, 1]);
            Assert.AreEqual(0, md2[2, 2, 2]);
            Assert.AreEqual(0, md2[2, 2, 3]);

            Assert.AreEqual(0, md2[2, 3, 1]);
            Assert.AreEqual(0, md2[2, 3, 2]);
            Assert.AreEqual(0, md2[2, 3, 3]);


            Assert.AreEqual(0, md2[3, 1, 1]);
            Assert.AreEqual(0, md2[3, 1, 2]);
            Assert.AreEqual(0, md2[3, 1, 3]);

            Assert.AreEqual(0, md2[3, 2, 1]);
            Assert.AreEqual(0, md2[3, 2, 2]);
            Assert.AreEqual(0, md2[3, 2, 3]);

            Assert.AreEqual(0, md2[3, 3, 1]);
            Assert.AreEqual(0, md2[3, 3, 2]);
            Assert.AreEqual(0, md2[3, 3, 3]);
        }

        [TestMethod]
        public void Matrix3DSetter()
        {
            List<int> d1indices = new List<int>();
            d1indices.Add(1);
            d1indices.Add(2);
            d1indices.Add(3);

            List<int> d2indices = new List<int>();
            d2indices.Add(1);
            d2indices.Add(2);
            d2indices.Add(3);

            List<int> d3indices = new List<int>();
            d3indices.Add(1);
            d3indices.Add(2);
            d3indices.Add(3);

            Matrix<int, int> md2 = new Matrix<int, int>(d1indices, d2indices, d3indices);


            md2[1, 1, 1] = 1;
            md2[1, 1, 2] = 2;
            md2[1, 1, 3] = 3;
            md2[1, 2, 1] = 4;
            md2[1, 2, 2] = 5;
            md2[1, 2, 3] = 6;
            md2[1, 3, 1] = 7;
            md2[1, 3, 2] = 8;
            md2[1, 3, 3] = 9;

            md2[2, 1, 1] = 10;
            md2[2, 1, 2] = 11;
            md2[2, 1, 3] = 12;
            md2[2, 2, 1] = 13;
            md2[2, 2, 2] = 14;
            md2[2, 2, 3] = 15;
            md2[2, 3, 1] = 16;
            md2[2, 3, 2] = 17;
            md2[2, 3, 3] = 18;

            md2[3, 1, 1] = 19;
            md2[3, 1, 2] = 20;
            md2[3, 1, 3] = 21;
            md2[3, 2, 1] = 22;
            md2[3, 2, 2] = 23;
            md2[3, 2, 3] = 24;
            md2[3, 3, 1] = 25;
            md2[3, 3, 2] = 26;
            md2[3, 3, 3] = 27;


            Assert.AreEqual(1, md2[1, 1, 1]);
            Assert.AreEqual(2, md2[1, 1, 2]);
            Assert.AreEqual(3, md2[1, 1, 3]);
            Assert.AreEqual(4, md2[1, 2, 1]);
            Assert.AreEqual(5, md2[1, 2, 2]);
            Assert.AreEqual(6, md2[1, 2, 3]);
            Assert.AreEqual(7, md2[1, 3, 1]);
            Assert.AreEqual(8, md2[1, 3, 2]);
            Assert.AreEqual(9, md2[1, 3, 3]);

            Assert.AreEqual(10, md2[2, 1, 1]);
            Assert.AreEqual(11, md2[2, 1, 2]);
            Assert.AreEqual(12, md2[2, 1, 3]);
            Assert.AreEqual(13, md2[2, 2, 1]);
            Assert.AreEqual(14, md2[2, 2, 2]);
            Assert.AreEqual(15, md2[2, 2, 3]);
            Assert.AreEqual(16, md2[2, 3, 1]);
            Assert.AreEqual(17, md2[2, 3, 2]);
            Assert.AreEqual(18, md2[2, 3, 3]);

            Assert.AreEqual(19, md2[3, 1, 1]);
            Assert.AreEqual(20, md2[3, 1, 2]);
            Assert.AreEqual(21, md2[3, 1, 3]);
            Assert.AreEqual(22, md2[3, 2, 1]);
            Assert.AreEqual(23, md2[3, 2, 2]);
            Assert.AreEqual(24, md2[3, 2, 3]);
            Assert.AreEqual(25, md2[3, 3, 1]);
            Assert.AreEqual(26, md2[3, 3, 2]);
            Assert.AreEqual(27, md2[3, 3, 3]);
        }

        [TestMethod]
        public void Matrix3DSetter2()
        {
            List<int> d1indices = new List<int>();
            d1indices.Add(1);
            d1indices.Add(2);
            d1indices.Add(3);

            List<int> d2indices = new List<int>();
            d2indices.Add(1);
            d2indices.Add(2);
            d2indices.Add(3);

            List<int> d3indices = new List<int>();
            d3indices.Add(1);
            d3indices.Add(2);
            d3indices.Add(3);

            Matrix<int, int> md2 = new Matrix<int, int>(d1indices, d2indices, d3indices);


            md2.SetItemAt(1, 0, 0, 0);
            md2.SetItemAt(2, 0, 0, 1);
            md2.SetItemAt(3, 0, 0, 2);
            md2.SetItemAt(4, 0, 1, 0);
            md2.SetItemAt(5, 0, 1, 1);
            md2.SetItemAt(6, 0, 1, 2);
            md2.SetItemAt(7, 0, 2, 0);
            md2.SetItemAt(8, 0, 2, 1);
            md2.SetItemAt(9, 0, 2, 2);

            md2.SetItemAt(10, 1, 0, 0);
            md2.SetItemAt(11, 1, 0, 1);
            md2.SetItemAt(12, 1, 0, 2);
            md2.SetItemAt(13, 1, 1, 0);
            md2.SetItemAt(14, 1, 1, 1);
            md2.SetItemAt(15, 1, 1, 2);
            md2.SetItemAt(16, 1, 2, 0);
            md2.SetItemAt(17, 1, 2, 1);
            md2.SetItemAt(18, 1, 2, 2);

            md2.SetItemAt(19, 2, 0, 0);
            md2.SetItemAt(20, 2, 0, 1);
            md2.SetItemAt(21, 2, 0, 2);
            md2.SetItemAt(22, 2, 1, 0);
            md2.SetItemAt(23, 2, 1, 1);
            md2.SetItemAt(24, 2, 1, 2);
            md2.SetItemAt(25, 2, 2, 0);
            md2.SetItemAt(26, 2, 2, 1);
            md2.SetItemAt(27, 2, 2, 2);


            Assert.AreEqual(1, md2.GetItemAt(0, 0, 0));
            Assert.AreEqual(2, md2.GetItemAt(0, 0, 1));
            Assert.AreEqual(3, md2.GetItemAt(0, 0, 2));
            Assert.AreEqual(4, md2.GetItemAt(0, 1, 0));
            Assert.AreEqual(5, md2.GetItemAt(0, 1, 1));
            Assert.AreEqual(6, md2.GetItemAt(0, 1, 2));
            Assert.AreEqual(7, md2.GetItemAt(0, 2, 0));
            Assert.AreEqual(8, md2.GetItemAt(0, 2, 1));
            Assert.AreEqual(9, md2.GetItemAt(0, 2, 2));

            Assert.AreEqual(10, md2.GetItemAt(1, 0, 0));
            Assert.AreEqual(11, md2.GetItemAt(1, 0, 1));
            Assert.AreEqual(12, md2.GetItemAt(1, 0, 2));
            Assert.AreEqual(13, md2.GetItemAt(1, 1, 0));
            Assert.AreEqual(14, md2.GetItemAt(1, 1, 1));
            Assert.AreEqual(15, md2.GetItemAt(1, 1, 2));
            Assert.AreEqual(16, md2.GetItemAt(1, 2, 0));
            Assert.AreEqual(17, md2.GetItemAt(1, 2, 1));
            Assert.AreEqual(18, md2.GetItemAt(1, 2, 2));

            Assert.AreEqual(19, md2.GetItemAt(2, 0, 0));
            Assert.AreEqual(20, md2.GetItemAt(2, 0, 1));
            Assert.AreEqual(21, md2.GetItemAt(2, 0, 2));
            Assert.AreEqual(22, md2.GetItemAt(2, 1, 0));
            Assert.AreEqual(23, md2.GetItemAt(2, 1, 1));
            Assert.AreEqual(24, md2.GetItemAt(2, 1, 2));
            Assert.AreEqual(25, md2.GetItemAt(2, 2, 0));
            Assert.AreEqual(26, md2.GetItemAt(2, 2, 1));
            Assert.AreEqual(27, md2.GetItemAt(2, 2, 2));
        }

        [TestMethod]
        public void Matrix3DGetIndexesAt01()
        {
            int x1 = 1;
            int x2 = 2;
            int x3 = 3;

            int y1 = 1;
            int y2 = 2;
            int y3 = 3;

            int z1 = 1;
            int z2 = 2;
            int z3 = 3;


            List<int> xIndices = new List<int>();
            xIndices.Add(x1);
            xIndices.Add(x2);
            xIndices.Add(x3);

            List<int> yIndices = new List<int>();
            yIndices.Add(y1);
            yIndices.Add(y2);
            yIndices.Add(y3);

            List<int> zIndices = new List<int>();
            zIndices.Add(z1);
            zIndices.Add(z2);
            zIndices.Add(z3);

            Matrix<int, int> m = new Matrix<int, int>(xIndices, yIndices, zIndices);



            Assert.AreEqual(x1, m.GetIndexesAt(0, 0, 0)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(0, 0, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(0, 0, 0)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 0, 1)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(0, 0, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(0, 0, 1)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 0, 2)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(0, 0, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(0, 0, 2)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 1, 0)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(0, 1, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(0, 1, 0)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 1, 1)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(0, 1, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(0, 1, 1)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 1, 2)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(0, 1, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(0, 1, 2)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 2, 0)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(0, 2, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(0, 2, 0)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 2, 1)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(0, 2, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(0, 2, 1)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 2, 2)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(0, 2, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(0, 2, 2)[2]);


            Assert.AreEqual(x2, m.GetIndexesAt(1, 0, 0)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(1, 0, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(1, 0, 0)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 0, 1)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(1, 0, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(1, 0, 1)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 0, 2)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(1, 0, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(1, 0, 2)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 1, 0)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(1, 1, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(1, 1, 0)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 1, 1)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(1, 1, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(1, 1, 1)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 1, 2)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(1, 1, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(1, 1, 2)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 2, 0)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(1, 2, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(1, 2, 0)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 2, 1)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(1, 2, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(1, 2, 1)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 2, 2)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(1, 2, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(1, 2, 2)[2]);


            Assert.AreEqual(x3, m.GetIndexesAt(2, 0, 0)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(2, 0, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(2, 0, 0)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 0, 1)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(2, 0, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(2, 0, 1)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 0, 2)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(2, 0, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(2, 0, 2)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 1, 0)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(2, 1, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(2, 1, 0)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 1, 1)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(2, 1, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(2, 1, 1)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 1, 2)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(2, 1, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(2, 1, 2)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 2, 0)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(2, 2, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(2, 2, 0)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 2, 1)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(2, 2, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(2, 2, 1)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 2, 2)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(2, 2, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(2, 2, 2)[2]);
        }

        [TestMethod]
        public void Matrix3DGetIndexesAt02()
        {
            Guid x1 = new Guid("{3300AD45-AE75-4A43-8959-3C97CCACBBF5}");
            Guid x2 = new Guid("{97005E3C-905D-4EEB-8974-1C838E878660}");
            Guid x3 = new Guid("{0599DBF2-704A-4E33-8D0C-5EDC18E5A02B}");

            Guid y1 = new Guid("{F976C1C0-5B8F-4479-80BA-ACE2327FC578}");
            Guid y2 = new Guid("{72FA58D4-3FB3-4B33-98FC-404D77BDDB7F}");
            Guid y3 = new Guid("{8D71063C-AF7D-4D4E-8042-FB34D7A52335}");

            Guid z1 = new Guid("{02E5C41E-A630-47A3-A041-290AD7D7E89B}");
            Guid z2 = new Guid("{487B12E8-B836-43AC-8D31-74A29214B3B1}");
            Guid z3 = new Guid("{49BECB30-F202-4A83-AC2C-8A9FC7CFAE64}");


            List<Guid> xIndices = new List<Guid>();
            xIndices.Add(x1);
            xIndices.Add(x2);
            xIndices.Add(x3);

            List<Guid> yIndices = new List<Guid>();
            yIndices.Add(y1);
            yIndices.Add(y2);
            yIndices.Add(y3);

            List<Guid> zIndices = new List<Guid>();
            zIndices.Add(z1);
            zIndices.Add(z2);
            zIndices.Add(z3);

            Matrix<Guid, int> m = new Matrix<Guid, int>(xIndices, yIndices, zIndices);


            Assert.AreEqual(x1, m.GetIndexesAt(0, 0, 0)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(0, 0, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(0, 0, 0)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 0, 1)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(0, 0, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(0, 0, 1)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 0, 2)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(0, 0, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(0, 0, 2)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 1, 0)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(0, 1, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(0, 1, 0)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 1, 1)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(0, 1, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(0, 1, 1)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 1, 2)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(0, 1, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(0, 1, 2)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 2, 0)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(0, 2, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(0, 2, 0)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 2, 1)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(0, 2, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(0, 2, 1)[2]);

            Assert.AreEqual(x1, m.GetIndexesAt(0, 2, 2)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(0, 2, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(0, 2, 2)[2]);


            Assert.AreEqual(x2, m.GetIndexesAt(1, 0, 0)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(1, 0, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(1, 0, 0)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 0, 1)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(1, 0, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(1, 0, 1)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 0, 2)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(1, 0, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(1, 0, 2)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 1, 0)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(1, 1, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(1, 1, 0)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 1, 1)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(1, 1, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(1, 1, 1)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 1, 2)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(1, 1, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(1, 1, 2)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 2, 0)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(1, 2, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(1, 2, 0)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 2, 1)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(1, 2, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(1, 2, 1)[2]);

            Assert.AreEqual(x2, m.GetIndexesAt(1, 2, 2)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(1, 2, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(1, 2, 2)[2]);


            Assert.AreEqual(x3, m.GetIndexesAt(2, 0, 0)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(2, 0, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(2, 0, 0)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 0, 1)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(2, 0, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(2, 0, 1)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 0, 2)[0]);
            Assert.AreEqual(y1, m.GetIndexesAt(2, 0, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(2, 0, 2)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 1, 0)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(2, 1, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(2, 1, 0)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 1, 1)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(2, 1, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(2, 1, 1)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 1, 2)[0]);
            Assert.AreEqual(y2, m.GetIndexesAt(2, 1, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(2, 1, 2)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 2, 0)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(2, 2, 0)[1]);
            Assert.AreEqual(z1, m.GetIndexesAt(2, 2, 0)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 2, 1)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(2, 2, 1)[1]);
            Assert.AreEqual(z2, m.GetIndexesAt(2, 2, 1)[2]);

            Assert.AreEqual(x3, m.GetIndexesAt(2, 2, 2)[0]);
            Assert.AreEqual(y3, m.GetIndexesAt(2, 2, 2)[1]);
            Assert.AreEqual(z3, m.GetIndexesAt(2, 2, 2)[2]);
        }


        [TestMethod]
        public void Matrix3DWithGuid01()
        {
            Guid x1 = new Guid("{C42DF629-BC62-4317-993F-94D6CC0A09FF}");
            Guid x2 = new Guid("{5067C337-DB10-4DEC-9E75-1EEC6A2DD381}");
            Guid x3 = new Guid("{8BFA632F-AC73-433C-84B1-50C6C375A1CD}");

            Guid y1 = new Guid("{AF1ED563-DA57-4ACA-B424-21F95A06FDAD}");
            Guid y2 = new Guid("{4C0DF4CC-1A8C-475E-895D-28EC8E2F94A1}");
            Guid y3 = new Guid("{95E3EA6B-0775-4ECC-B87D-6B4F5E19552C}");

            Guid z1 = new Guid("{E85AF341-BD71-4CC0-89BF-B1520826E3DC}");
            Guid z2 = new Guid("{1CDD46F1-0446-45E5-AE31-B3F52B53AEB7}");
            Guid z3 = new Guid("{31C4D13F-C913-4D6E-8E4B-F946E4F5DB61}");

            List<Guid> d1indices = new List<Guid>();
            d1indices.Add(x1);
            d1indices.Add(x2);
            d1indices.Add(x3);

            List<Guid> d2indices = new List<Guid>();
            d2indices.Add(y1);
            d2indices.Add(y2);
            d2indices.Add(y3);

            List<Guid> d3indices = new List<Guid>();
            d3indices.Add(z1);
            d3indices.Add(z2);
            d3indices.Add(z3);

            Matrix<Guid, int> m = new Matrix<Guid, int>(d1indices, d2indices, d3indices);


            m.SetItemAt(1, 0, 0, 0);
            m.SetItemAt(2, 0, 0, 1);
            m.SetItemAt(3, 0, 0, 2);
            m.SetItemAt(4, 0, 1, 0);
            m.SetItemAt(5, 0, 1, 1);
            m.SetItemAt(6, 0, 1, 2);
            m.SetItemAt(7, 0, 2, 0);
            m.SetItemAt(8, 0, 2, 1);
            m.SetItemAt(9, 0, 2, 2);

            m.SetItemAt(10, 1, 0, 0);
            m.SetItemAt(11, 1, 0, 1);
            m.SetItemAt(12, 1, 0, 2);
            m.SetItemAt(13, 1, 1, 0);
            m.SetItemAt(14, 1, 1, 1);
            m.SetItemAt(15, 1, 1, 2);
            m.SetItemAt(16, 1, 2, 0);
            m.SetItemAt(17, 1, 2, 1);
            m.SetItemAt(18, 1, 2, 2);

            m.SetItemAt(19, 2, 0, 0);
            m.SetItemAt(20, 2, 0, 1);
            m.SetItemAt(21, 2, 0, 2);
            m.SetItemAt(22, 2, 1, 0);
            m.SetItemAt(23, 2, 1, 1);
            m.SetItemAt(24, 2, 1, 2);
            m.SetItemAt(25, 2, 2, 0);
            m.SetItemAt(26, 2, 2, 1);
            m.SetItemAt(27, 2, 2, 2);

            Assert.AreEqual(1, m.GetItemAt(0, 0, 0));
            Assert.AreEqual(2, m.GetItemAt(0, 0, 1));
            Assert.AreEqual(3, m.GetItemAt(0, 0, 2));
            Assert.AreEqual(4, m.GetItemAt(0, 1, 0));
            Assert.AreEqual(5, m.GetItemAt(0, 1, 1));
            Assert.AreEqual(6, m.GetItemAt(0, 1, 2));
            Assert.AreEqual(7, m.GetItemAt(0, 2, 0));
            Assert.AreEqual(8, m.GetItemAt(0, 2, 1));
            Assert.AreEqual(9, m.GetItemAt(0, 2, 2));

            Assert.AreEqual(10, m.GetItemAt(1, 0, 0));
            Assert.AreEqual(11, m.GetItemAt(1, 0, 1));
            Assert.AreEqual(12, m.GetItemAt(1, 0, 2));
            Assert.AreEqual(13, m.GetItemAt(1, 1, 0));
            Assert.AreEqual(14, m.GetItemAt(1, 1, 1));
            Assert.AreEqual(15, m.GetItemAt(1, 1, 2));
            Assert.AreEqual(16, m.GetItemAt(1, 2, 0));
            Assert.AreEqual(17, m.GetItemAt(1, 2, 1));
            Assert.AreEqual(18, m.GetItemAt(1, 2, 2));

            Assert.AreEqual(19, m.GetItemAt(2, 0, 0));
            Assert.AreEqual(20, m.GetItemAt(2, 0, 1));
            Assert.AreEqual(21, m.GetItemAt(2, 0, 2));
            Assert.AreEqual(22, m.GetItemAt(2, 1, 0));
            Assert.AreEqual(23, m.GetItemAt(2, 1, 1));
            Assert.AreEqual(24, m.GetItemAt(2, 1, 2));
            Assert.AreEqual(25, m.GetItemAt(2, 2, 0));
            Assert.AreEqual(26, m.GetItemAt(2, 2, 1));
            Assert.AreEqual(27, m.GetItemAt(2, 2, 2));






            Assert.AreEqual(1, m[x1, y1, z1]);
            Assert.AreEqual(2, m[x1, y1, z2]);
            Assert.AreEqual(3, m[x1, y1, z3]);
            Assert.AreEqual(4, m[x1, y2, z1]);
            Assert.AreEqual(5, m[x1, y2, z2]);
            Assert.AreEqual(6, m[x1, y2, z3]);
            Assert.AreEqual(7, m[x1, y3, z1]);
            Assert.AreEqual(8, m[x1, y3, z2]);
            Assert.AreEqual(9, m[x1, y3, z3]);

            Assert.AreEqual(10, m[x2, y1, z1]);
            Assert.AreEqual(11, m[x2, y1, z2]);
            Assert.AreEqual(12, m[x2, y1, z3]);
            Assert.AreEqual(13, m[x2, y2, z1]);
            Assert.AreEqual(14, m[x2, y2, z2]);
            Assert.AreEqual(15, m[x2, y2, z3]);
            Assert.AreEqual(16, m[x2, y3, z1]);
            Assert.AreEqual(17, m[x2, y3, z2]);
            Assert.AreEqual(18, m[x2, y3, z3]);

            Assert.AreEqual(19, m[x3, y1, z1]);
            Assert.AreEqual(20, m[x3, y1, z2]);
            Assert.AreEqual(21, m[x3, y1, z3]);
            Assert.AreEqual(22, m[x3, y2, z1]);
            Assert.AreEqual(23, m[x3, y2, z2]);
            Assert.AreEqual(24, m[x3, y2, z3]);
            Assert.AreEqual(25, m[x3, y3, z1]);
            Assert.AreEqual(26, m[x3, y3, z2]);
            Assert.AreEqual(27, m[x3, y3, z3]);
        }

        #endregion
    }
}
