using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jitter.Models
{
    public class JitterRepository
    {
        private JitterContext _context;
        public JitterContext Context { get {return _context;}}

        public JitterRepository()
        {
            _context = new JitterContext();
        }

        public JitterRepository(JitterContext a_context) // allows to define which context we want to use
        {  // takes connection string from passed in context
            _context = a_context;
        }

        public List<JitterUser> GetAllUsers()
        {
            // will get data from DbSet JitterUsers
            // wrap every row in table w/ instance of JitterUser class
            // (same as "AS" in SQL)
            var query = from users in _context.JitterUsers select users;
            return query.ToList();
        }
    }
}