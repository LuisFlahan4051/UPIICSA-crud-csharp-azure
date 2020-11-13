namespace zapatosUPIICSA
{
    class MainUserCapsule
    {
        private int idPriv;
        private string namePriv;
        private string passwordPriv;
        private string emailPriv;
        private string phonePriv;

        public int Id_user
        {
            get
            {
                return idPriv;
            }
            set
            {
                idPriv = value;
            }
        }

        public string Name_user
        {
            get
            {
                return namePriv;
            }
            set
            {
                namePriv = value;
            }
        }

        public string Password_user
        {
            get
            {
                return passwordPriv;
            }
            set
            {
                passwordPriv = value;
            }
        }

        public string Email_user
        {
            get
            {
                return emailPriv;
            }
            set
            {
                emailPriv = value;
            }
        }

        public string Phone_user
        {
            get
            {
                return phonePriv;
            }
            set
            {
                phonePriv = value;
            }
        }
    }
}
