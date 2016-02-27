using System;

namespace Core
{
    //TODO: Make Entity

    public sealed class Character
    {
        /// <summary>
        /// Provides the base implementation for a character
        /// </summary>
        /// <param name="id"></param>
       
        public Character(Guid id)
        {
            Id = id;
        }


        public Guid Id { get; }
    }
}
