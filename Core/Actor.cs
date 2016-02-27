using System;
using Core.General;

namespace Core
{

    public sealed class Actor: Entity<Guid>
    {
        /// <summary>
        /// Provides the base implementation for a character
        /// </summary>
        /// <param name="id"></param>
       
        public Actor(Guid id) : base(id)
        {
        }


    }
}
