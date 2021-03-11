using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task_1;

namespace Task1_UnitTests
{
    [TestClass]
    public class Tests
    {
        #region Tests_RandomString

        [TestMethod]
        public void Test_RandomString_NotEqual()
        {
            //Arrange
            StringGenerator stringGenerator = new StringGenerator();
            string str1 = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            int stringLegth = 5;

            //Act
            str1 = stringGenerator.GetRandomString(stringLegth);
            str2 = stringGenerator.GetRandomString(stringLegth);
            str3 = stringGenerator.GetRandomString(stringLegth);

            //Assert
            Assert.AreEqual(false, str1 == str2, "ќжидаетс€ false.");
            Assert.AreEqual(false, str2 == str3, "ќжидаетс€ false.");
        }

        [TestMethod]
        public void Test_RandomString_StringLength()
        {
            //Arrange
            StringGenerator stringGenerator = new StringGenerator();
            string str1 = string.Empty;
            int stringLegth = 5;

            //Act
            str1 = stringGenerator.GetRandomString(stringLegth);

            //Assert
            Assert.AreEqual(stringLegth, str1.Length, "ќжидаетс€ значение равное stringLength.");
        }

        #endregion

        #region Tests_RandomArray

        [TestMethod]
        public void Test_RandomStringArray_NotEqual()
        {
            //Arrange
            int stringLegth = 5;
            int arrayLength = 10000;
            bool equal = false;
            StringGenerator stringGenerator = new StringGenerator();

            //Act
            string[] randomArray = stringGenerator.GetRandomStringArray(arrayLength, stringLegth);
            for (int i = 0; i < arrayLength - 1; i++)
            {
                if (randomArray[i] == randomArray[i + 1])
                {
                    equal = true;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(false, equal, "ќжидаетс€ false");
        }

        [TestMethod]
        public void Test_RandomStringArray_NotEmpty()
        {
            //Arrange
            int stringLegth = 5;
            int arrayLength = 10000;
            bool equal = false;
            StringGenerator stringGenerator = new StringGenerator();

            //Act
            string[] randomArray = stringGenerator.GetRandomStringArray(arrayLength, stringLegth);
            for (int i = 0; i < arrayLength; i++)
            {
                if (randomArray[i] == string.Empty)
                {
                    equal = true;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(false, equal, "ќжидаетс€ false");
        }

        [TestMethod]
        public void Test_RandomStringArray_Count()
        {
            //Arrange
            int stringLegth = 5;
            int arrayLength = 10000;
            StringGenerator stringGenerator = new StringGenerator();

            //Act
            string[] randomArray = stringGenerator.GetRandomStringArray(arrayLength, stringLegth);

            //Assert
            Assert.AreEqual(arrayLength, randomArray.Length, "ќжидаетс€ значение равное arrayLength");
        }

        [TestMethod]
        public void Test_RandomStringArray_StringsLength()
        {
            //Arrange
            int stringLegth = 5;
            int arrayLength = 10000;
            bool equal = true;
            StringGenerator stringGenerator = new StringGenerator();

            //Act
            string[] randomArray = stringGenerator.GetRandomStringArray(arrayLength, stringLegth);
            for (int i = 0; i < arrayLength; i++)
            {
                if (randomArray[i].Length != stringLegth)
                {
                    equal = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, equal, "ќжидаетс€ значение true");
        }

        #endregion

        #region Tests_HashSet

        [TestMethod]
        public void Test_GetHashSet_HashCount()
        {
            //Arrange
            int stringLegth = 5;
            int arrayLength = 10000;
            StringGenerator stringGenerator = new StringGenerator();

            //Act
            HashSet<string> hash0 = stringGenerator.GetHashSet(arrayLength, stringLegth);
            HashSet<string> hash1 = stringGenerator.GetHashSet(arrayLength, stringLegth);
            HashSet<string> hash2 = stringGenerator.GetHashSet(arrayLength, stringLegth);

            //Assert
            Assert.AreEqual(arrayLength, hash0.Count, "ќжидаетс€ значение равное stringLength");
            Assert.AreEqual(arrayLength, hash1.Count, "ќжидаетс€ значение равное stringLength");
            Assert.AreEqual(arrayLength, hash2.Count, "ќжидаетс€ значение равное stringLength");
        }

        #endregion

        #region Tests_StringFinder

        [TestMethod]
        public void Test_StringFinder_Contain()
        {
            //Arrange
            int stringLegth = 5;
            int arrayLength = 10000;
            int index1 = 0;
            int index2 = 5000;
            int index3 = 9999;

            int searchIndex1 = -1;
            int searchIndex2 = -1;
            int searchIndex3 = -1;

            string[] strArray = new string[arrayLength];
            StringGenerator stringGenerator = new StringGenerator();
            StringFinder stringFinder = new StringFinder();

            //Act
            strArray = stringGenerator.GetRandomStringArray(arrayLength, stringLegth);
            searchIndex1 = stringFinder.Find(strArray[index1], strArray);
            searchIndex2 = stringFinder.Find(strArray[index2], strArray);
            searchIndex3 = stringFinder.Find(strArray[index3], strArray);

            //Assert
            Assert.AreEqual(index1, searchIndex1, "ќжидаетс€ значение равное index1");
            Assert.AreEqual(index2, searchIndex2, "ќжидаетс€ значение равное index2");
            Assert.AreEqual(index3, searchIndex3, "ќжидаетс€ значение равное index3");
        }

        [TestMethod]
        public void Test_StringFinder_NotContain()
        {
            //Arrange
            int stringLegth = 5;
            int arrayLength = 10000;
            string searchString = "dfnked";     //строка длиной на 1 символ больше, чем содержащиес€ в hashSet
            int searchIndex = -1;

            string[] strArray = new string[arrayLength];
            StringGenerator stringGenerator = new StringGenerator();
            StringFinder stringFinder = new StringFinder();

            //Act
            strArray = stringGenerator.GetRandomStringArray(arrayLength, stringLegth);
            searchIndex = stringFinder.Find(searchString, strArray);

            //Assert
            Assert.AreEqual(-1, searchIndex, "ожидаетс€ -1");
        }

        #endregion
    }
}