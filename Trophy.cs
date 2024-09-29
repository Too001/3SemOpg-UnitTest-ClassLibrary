namespace _3SemObligatoriskOpgave_1_og_2
{
    public class Trophy
    {
        public int Id { get; set; }
        public string Competetion { get; set; }
        public int Year { get; set; }

        public void ValidateCompetition()
        {
            if (Competetion == null)
            { 
                throw new ArgumentNullException("Competition cannot be null"); 
            }
            if (Competetion.Length < 3)
            { 
                throw new ArgumentOutOfRangeException("Competition must be equal to or over 3 characters:" + Competetion); 
            }
        }

        public void ValidateYearLow()
        {
            if (Year < 1970) { throw new ArgumentOutOfRangeException("Year must be under 1970" + Year); }
        }

        public void ValidateYearHigh()
        {
            if (Year > 2024)
            {
                throw new ArgumentOutOfRangeException("Year must be under 2024" + Year);
            }
        }

        public override string ToString()
        {
            return $"{Id} {Competetion} {Year}";
        }

        public void Validate()
        {
            ValidateCompetition();
            ValidateYearLow();
            ValidateYearHigh();
        }
    }
}
