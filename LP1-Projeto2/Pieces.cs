namespace LP1_Projeto2
{
    /// <summary>
    /// Creates the peaces with the various atributes
    /// </summary>
    public class Pieces
    {
        private string name;
        private int [] pos;
        private bool alive;

        public Pieces(string name ,int [] pos)
        {
            this.name = name;
            this.pos = pos;
            alive = true;
        }

        public string GetName()
        {
            return name;
        }

        public int [] GetPos()
        {
            return pos;
        }
        public void SetPos(int [] pos)
        {
            this.pos = pos;
        }

        public bool GetAlive()
        {
            return alive;
        }

        public void SetAlive(bool alive)
        {
            this.alive = alive;
        }
    }
}