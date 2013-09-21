using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebMMO {
    public class FormManager {
        private static FormManager _Instance;
        public static FormManager Instance {
            get {
                if(_Instance == null){
                    _Instance = new FormManager();
                }
                return _Instance;
            }
        }

        private List<Form> m_FormList = new List<Form>();

        public static void RunForm(Form form) {
            form.Show();
            Instance.m_FormList.Add(form);
        }

        public static void CloseForm(Form form) {
            Instance.m_FormList.Remove(form);
            form.Close();
        }
    }
}
