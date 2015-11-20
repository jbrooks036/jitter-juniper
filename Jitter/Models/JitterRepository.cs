using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jitter.Models
{
    public class JitterRepository
    {
        private JitterContext _context;
        public JitterContext Context { get {return _context;} }

        public JitterRepository()
        {
            _context = new JitterContext();
        }

        public JitterRepository(JitterContext a_context)
        {
            // this allows us to inject a context, can be used for testing
            _context = a_context;  // ensure always starts w/ a jitter context
        }

        public List<JitterUser> GetAllUsers()
        {
            return null;
        }
    }
}