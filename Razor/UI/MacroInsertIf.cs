using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Assistant.Macros;

namespace Assistant
{
    /// <summary>
    /// Summary description for MacroInsertIf.
    /// </summary>
    public class MacroInsertIf : System.Windows.Forms.Form
    {
        private Macro m_Macro;
        private int m_Idx;
        private MacroAction m_Action;

        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ComboBox varList;
        private System.Windows.Forms.ComboBox opList;
        private System.Windows.Forms.Label label1;

        private IfAction.IfVarType[] cb2IfVar; // combobox index -> ifvar type association
        private int[] ifVar2Cb;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public MacroInsertIf( Macro m, int idx )
        {
            m_Macro = m;
            m_Idx = idx;
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            
            foreach ( Counter c in Counter.List )
                varList.Items.Add( c.Name );
        }

        public MacroInsertIf( MacroAction a )
        {
            m_Action = a;
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            foreach ( Counter c in Counter.List )
                varList.Items.Add( c.Name );
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.insert = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.varList = new System.Windows.Forms.ComboBox();
            this.cancel = new System.Windows.Forms.Button();
            this.opList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(32, 36);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(76, 24);
            this.insert.TabIndex = 0;
            this.insert.Text = "&Insert";
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(144, 9);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(80, 20);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.Text = "";
            // 
            // varList
            // 
            this.varList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.varList.Items.AddRange(new object[] {
                                                          "Hits",
                                                          "Mana",
                                                          "Stamina",
                                                          "Poisoned",
                                                          "SysMessage",
                                                          "PlayerMessage",
                                                          "Weight",
                                                          "Mounted",
                                                          "R Hand Empty",
                                                          "L Hand Empty",
                                                          "Hidden"});
            this.varList.Location = new System.Drawing.Point(24, 8);
            this.varList.Name = "varList";
            this.varList.Size = new System.Drawing.Size(80, 21);
            this.varList.TabIndex = 8;
            this.varList.SelectedIndexChanged += new System.EventHandler(this.varList_SelectedIndexChanged);
            //
            // cb2IfVar mapping
            // 
            cb2IfVar = new IfAction.IfVarType[] { 
                IfAction.IfVarType.Hits,
                IfAction.IfVarType.Mana,
                IfAction.IfVarType.Stamina,
                IfAction.IfVarType.Poisoned,
                IfAction.IfVarType.SysMessage,
                IfAction.IfVarType.PlayerMessage,
                IfAction.IfVarType.Weight,
                IfAction.IfVarType.Mounted,
                IfAction.IfVarType.RHandEmpty,
                IfAction.IfVarType.LHandEmpty,
                IfAction.IfVarType.Hidden
            };

            ifVar2Cb = new int[] {
                0,1,2,3,4,6,7,8,9,5,10
            };

            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(124, 36);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(76, 24);
            this.cancel.TabIndex = 10;
            this.cancel.Text = "&Cancel";
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // opList
            // 
            this.opList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.opList.Items.AddRange(new object[] {
                                                            "<=",
                                                            ">="});
            this.opList.Location = new System.Drawing.Point(104, 8);
            this.opList.Name = "opList";
            this.opList.Size = new System.Drawing.Size(40, 21);
            this.opList.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "If:";
            // 
            // MacroInsertIf
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(230, 68);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.opList);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.varList);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.insert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MacroInsertIf";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert If...";
            this.Load += new System.EventHandler(this.MacroInsertIf_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private void cancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void insert_Click(object sender, System.EventArgs e)
        {
            MacroAction a = null;

            try
            {
                IfAction.IfVarType selType = varList.SelectedIndex < cb2IfVar.Length ? cb2IfVar[varList.SelectedIndex] : IfAction.IfVarType.BeginCountersMarker;
                if ( selType == IfAction.IfVarType.SysMessage || selType == IfAction.IfVarType.PlayerMessage)
                    a = new IfAction( selType, txtAmount.Text );
                else if ( selType >= IfAction.IfVarType.BeginCountersMarker )
                    a = new IfAction( IfAction.IfVarType.Counter, (sbyte)opList.SelectedIndex, Utility.ToInt32( txtAmount.Text, 0 ), varList.SelectedItem as string );
                else
                    a = new IfAction( selType, (sbyte)opList.SelectedIndex, Utility.ToInt32( txtAmount.Text, 0 ) );
            }
            catch
            {
                return;
            }

            if ( m_Action == null )
                m_Macro.Insert( m_Idx+1, a );
            else
                m_Action.Parent.Convert( m_Action, a );
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void MacroInsertIf_Load(object sender, System.EventArgs e)
        {
            Language.LoadControlNames( this );

            if ( m_Action is IfAction )
            {
                try {
                    int n = (int)((IfAction)m_Action).Variable;
                    varList.SelectedIndex = n < ifVar2Cb.Length ? ifVar2Cb[n] : n; 
                } catch {}
                try { opList.SelectedIndex = (int)((IfAction)m_Action).Op; } catch {}
                try
                {
                    if ( varList.SelectedIndex != 3 && ( varList.SelectedIndex <= 6 || varList.SelectedIndex >= (int)IfAction.IfVarType.BeginCountersMarker ) )
                        txtAmount.Text = ((IfAction)m_Action).Value.ToString();
                }
                catch
                {
                }

                if ( ((IfAction)m_Action).Counter != null && ((IfAction)m_Action).Variable == IfAction.IfVarType.Counter )
                    try { varList.SelectedItem = ((IfAction)m_Action).Counter; } catch {}
            }
        }

        private void varList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                opList.Visible = varList.SelectedIndex < 3 || varList.SelectedIndex == 6 || varList.SelectedIndex >= (int)IfAction.IfVarType.BeginCountersMarker;
                txtAmount.Visible = varList.SelectedIndex != 3 && ( varList.SelectedIndex <= 6 || varList.SelectedIndex >= (int)IfAction.IfVarType.BeginCountersMarker );
            }
            catch
            {
            }

            if ( !opList.Visible )
            {
                if ( txtAmount.Visible )
                {
                    varList.Size = new System.Drawing.Size(80, 21);

                    txtAmount.Location = new System.Drawing.Point(104, 9);
                    txtAmount.Size = new System.Drawing.Size(120, 20);
                }
                else
                {
                    varList.Size = new System.Drawing.Size(200, 21);
                }
            }
            else
            {
                varList.Size = new System.Drawing.Size(80, 21);

                txtAmount.Location = new System.Drawing.Point(144, 9);
                txtAmount.Size = new System.Drawing.Size(80, 20);
            }
        }
    }
}
