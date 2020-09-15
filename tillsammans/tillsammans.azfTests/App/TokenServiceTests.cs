using Microsoft.VisualStudio.TestTools.UnitTesting;
using tillsammans.App;
using System;
using System.Collections.Generic;
using System.Text;
using tillsammans.Auth;

namespace tillsammans.App.Tests
{
    [TestClass()]
    public class TokenServiceTests
    {

        [TestMethod()]
        public void CreateTokenTest_Same_Input_Should_Create_Identical_Tokens()
        {
            //arrange
            var sut = new TokenService();

            //act
            var token1 = sut.CreateToken("userId=123", "appkey123", "uniqueforuser1");
            var token2 = sut.CreateToken("userId=123", "appkey123", "uniqueforuser1");

            //assert
            Assert.AreEqual(token1, token2);

        }

        [TestMethod()]
        public void CreateTokenTest_Different_Keys_Should_Create_Different_Tokens()
        {
            //arrange
            var sut = new TokenService();

            //act
            var token1 = sut.CreateToken("userId=123", "AA", "uniqueforuser1");
            var token2 = sut.CreateToken("userId=123", "BB", "uniqueforuser1");

            //assert
            Assert.AreNotEqual(token1, token2);

        }

        [TestMethod()]
        public void CreateTokenTest_Different_Salt_Should_Create_Different_Tokens()
        {
            //arrange
            var sut = new TokenService();

            //act
            var token1 = sut.CreateToken("userId=123", "appkey123", "uniqueforuser1");
            var token2 = sut.CreateToken("userId=123", "appkey123", "uniqueforuser2");

            //assert
            Assert.AreNotEqual(token1, token2);

        }

        [TestMethod()]
        public void ValidateTokenTest_Equal_Is_Valid()
        {
            //arrange
            var sut = new TokenService();
            var token = sut.CreateToken("userId=123", "appkey123", "uniqueforuser1");

            //act
            var isValid = sut.ValidateToken(token ,"userId=123", "appkey123", "uniqueforuser1");

            //assert
            Assert.IsTrue(isValid);

        }
        [TestMethod()]
        public void ValidateTokenTest_Different_Is_Not_Valid()
        {
            //arrange
            var sut = new TokenService();
            var token = sut.CreateToken("userId=123", "appkey123", "uniqueforuser1");

            //act
            var isValid = sut.ValidateToken(token, "userId=111", "appkey123", "uniqueforuser1");

            //assert
            Assert.IsFalse(isValid);

        }
    }
}