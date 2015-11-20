using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jitter.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;   // gives access to DbSet

namespace Jitter.Tests.Models
{
    [TestClass]
    public class JitterRepositoryTests
    {
        [TestMethod]
        public void JitterContextEnsureICanCreateInstance()
        {
            JitterContext context = new JitterContext();
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void JitterRepositoryEnsureICanCreateInstance()
        {
            JitterRepository repository = new JitterRepository();
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void JitterRepositoryEnsureICanGetAllUsers()
        {
            // 1) figure out where dependencies are
            // 2) would like for repo to use dbcontext

            // Arrange
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "adam1" },
                new JitterUser { Handle = "rumbadancer2" }
            };

            // this next section goes beyond "Seed Data" from Cohort 7
            // connect repository to mock_context; 
            Mock<JitterContext> mock_context = new Mock<JitterContext>(); // accepts all JitterContext methods into Moq, mock DB for testing
            Mock<DbSet<JitterUser>> mock_set = new Mock<DbSet<JitterUser>>();  // Type is same as from DbSet in JitterContext

            mock_set.Object.AddRange(expected);  // How awesome: ... Types match up here

            // this is stubbing the JitterUsers property getter
            mock_context.Setup(a => a.JitterUsers).Returns(mock_set.Object); // what kind of signature to look for?  [Linq expression]; 'a' reps instance of JitterContext
            JitterRepository repository = new JitterRepository(mock_context.Object); // .Object is convention to provide object from inside mock_context

            // Act
            var actual = repository.GetAllUsers(); // how we *want* to be able to work w/ it

            // Assert
            // Assert.AreEqual("adam1", actual.First().Handle);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void JitterRepositoryEnsureIHaveAContext()
        {
            // Arrange
            JitterRepository repository = new JitterRepository();

            // Act
            var actual = repository.Context;

            // Assert
            Assert.IsInstanceOfType(actual, typeof(JitterContext));

        }
    }
}
