using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sploosh
{
    public partial class Form1 : Form
    {
        int runs = 0;
        Button[,] btnList = new Button[8,8] {{null,null,null,null,null,null,null,null},{null,null,null,null,null,null,null,null},{null,null,null,null,null,null,null,null},{null,null,null,null,null,null,null,null},{null,null,null,null,null,null,null,null},{null,null,null,null,null,null,null,null},{null,null,null,null,null,null,null,null},{null,null,null,null,null,null,null,null}};
        public Form1()
        {
            int start = 12;
            int dist = 6;
            int size = 30;
            
            InitializeComponent();
            for (int i = 0; i < 8; i++)
            {
                for (int i2 = 0; i2 < 8; i2++)
                {
                    Point loc1 = new Point(start + i2*(size+dist), start + i*(size+dist));
                    Size size1 = new Size(size,size);
                    Button btnNew = new Button();
                    btnNew.Location = loc1;
                    btnNew.Size = size1;
                    btnNew.Name = i2.ToString() +";"+ i.ToString();
                    btnNew.Tag = 0;
                    btnNew.MouseUp +=  new MouseEventHandler(Buttons_Click);
                  
                    btnNew.MouseEnter += new EventHandler(Buttons_Mouse);
                    this.Controls.Add(btnNew);
                    btnList[i2, i] = btnNew;
                }
            }
        } static Random rdm = new Random();
        Boolean[,] field = new Boolean[8, 8] { {false,false,false,false,false,false,false,false},{false,false,false,false,false,false,false,false},{false,false,false,false,false,false,false,false},{false,false,false,false,false,false,false,false},{false,false,false,false,false,false,false,false},{false,false,false,false,false,false,false,false},{false,false,false,false,false,false,false,false},{false,false,false,false,false,false,false,false} };
        int[,] heatmap = new int[8 , 8] {{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0}};
        double highest = 0;
       double total = 0;
        
        
        int amount = 10000;
        int conditionMet = 0;

        
         void simulation()
         {
             runs = 0;
             total = 0;
             highest = 0;
             field = new Boolean[8, 8] { {false,false,false,false,false,false,false,false},{false,false,false,false,false,false,false,false},{false,false,false,false,false,false,false,false},{false,false,false,false,false,false,false,false},{false,false,false,false,false,false,false,false},{false,false,false,false,false,false,false,false},{false,false,false,false,false,false,false,false},{false,false,false,false,false,false,false,false} };
             conditionMet = 0;
             heatmap = new int[8 , 8] {{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0}};

            while(conditionMet<amount)
            {
                field = new Boolean[8, 8]
                {
                    {false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false}
                };
                addEnemy(2);
                addEnemy(3);
                addEnemy(4);
                drawField();
                runs++;
                if(conditions()){
                  
                    addToHeatMap();
                }
                else
                {
                   
                }
                Console.WriteLine(conditionMet.ToString());
            }
            for (int i = 0; i < 8; i++)
            {
                for (int i2 = 0; i2 < 8; i2++)
                {
                    total += heatmap[i, i2];
 


                }
            }

            drawUI();
        }

      void drawField()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int i2 = 0; i2 < 7; i2++)
                {
                    if (field[i2, i] == true)
                    {
                      
                    }
                    else
                    {
                       
                    }
                }
                if (field[7, i] == true)
                {
                  
                }
                else
                {
                   
                }
            }
        }
        Boolean conditions()
        {
          
            for (int i = 0; i < 8; i++)
            {
                for (int i2 = 0; i2 < 8; i2++)
                {
                    if ((int) btnList[i2, i].Tag == 1 && field[i2, i] == true)
                    {
                      
                        return false;
                      
                    }
                    if ((int) btnList[i2, i].Tag == 2 && field[i2, i] == false)
                    {
                      
                        return false;
                      
                    }

                }   
            }   
        
                conditionMet++;
                return true;
            
            
            
        }
        void addEnemy(int length)
        {
            int[] pos = new int[]{0,0};
           
            Boolean checkValid = false;
            int dir;
            int redir = 0;
            pos[0] = rdm.Next(0, 8);
            pos[1] = rdm.Next(0, 8);
            do
            {
                dir = rdm.Next(0, 4);
                checkValid = true;
                if (dir == 0 && pos[1] - length <= 0)
                {
                    checkValid = false;
                }
                if (dir == 1 && pos[0] + length  >= 7)
                {
                    checkValid = false;
                }
                if (dir == 2 && pos[1] + length  >= 7)
                {
                    checkValid = false;
                }
                if (dir == 3 && pos[0] - length <= 0)
                {
                    checkValid = false;
                }

                if (checkValid)
                {

                    if (dir == 0)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            if (field[pos[0], pos[1] - i] == true)
                            {
                                checkValid = false;
                            }
                        }
                    }
                    else if (dir == 1)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            if (field[pos[0] + i, pos[1]] == true)
                            {
                                checkValid = false;
                            }
                        }
                    }
                    else if (dir == 2)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            if (field[pos[0], pos[1] + i] == true)
                            {
                                checkValid = false;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < length; i++)
                        {

                            if (field[pos[0] - i, pos[1]] == true)
                            {
                                checkValid = false;
                            }



                        }
                    }


                }

                redir++;
                if (redir > 3&&!checkValid)
                {
                    pos[0] = rdm.Next(0, 8);
                    pos[1] = rdm.Next(0, 8);
                    redir = 0;
                }
            } while (!checkValid);
            
            
           
            if (dir == 0)
            {
                for (int i = 0; i < length; i++)
                {
                    field[pos[0]  , pos[1] - i] = true;
                }
               
            }
            else if (dir == 1)
            {
                for (int i = 0; i < length; i++)
                {
                    field[pos[0] + i , pos[1] ] = true;
                }
            }
            else if (dir == 2)
            {
                for (int i = 0; i < length; i++)
                {
                    field[pos[0] , pos[1] +i] = true;
                }           
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    field[pos[0]  - i, pos[1] ] = true;
                }
            }
        }

        void addToHeatMap()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int i2 = 0; i2 < 8; i2++)
                {
                    if (field[i, i2] == true)
                    {
                        heatmap[i, i2]++;
                        if (heatmap[i, i2] > highest)
                        {
                            highest = heatmap[i, i2];
                            
                        }
                    }
                }
            }

        }

        void drawUI()
        {
            highest = highest/Convert.ToDouble(conditionMet) ;
            double average = total/Convert.ToDouble(conditionMet  * 64);
            label2.Text = ((1-(Convert.ToDouble(conditionMet) / Convert.ToDouble(runs)))*100).ToString();
            for (int i = 0; i < 8; i++)
            {
                for (int i2 = 0; i2 < 8; i2++)
                {
                  Double percentage = Convert.ToDouble(heatmap[i2,i]) / Convert.ToDouble(conditionMet);
            
                  if (percentage == 0)
                  {
                      btnList[i2, i].BackColor = Color.White;
                  }
             
                  else if (percentage < average)
                  {
                      btnList[i2, i].BackColor = Color.Green;
                  }
                  else if(percentage<1.2 * average)
                  {
                      btnList[i2, i].BackColor = Color.Yellow;
                  }else if (percentage > 0.95 * highest)
                  {
                      btnList[i2, i].BackColor = Color.Purple;
                  }
                  else
                  {
                      btnList[i2, i].BackColor = Color.Red;
                  }
                }
                
            }
         
        }
        
        
        private void Buttons_Click(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left){
                Button clickedButton = (Button) sender;
                clickedButton.Text = "X";
                clickedButton.Tag = 1;
                
            }
            else
            {
                
                Button clickedButton = (Button) sender;
                clickedButton.Text = "O";
                clickedButton.Tag = 2;
            }
        

            simulation();
        }
        private void Buttons_RightClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;
            clickedButton.Text = "O";
            clickedButton.Tag = 2;

            simulation();
        }
        private void Buttons_Mouse(object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;
            int x = Convert.ToInt32(clickedButton.Name.Split(';')[0]);
            int y = Convert.ToInt32(clickedButton.Name.Split(';')[1]);
            double percentage = Convert.ToDouble(heatmap[x, y]) / Convert.ToDouble(conditionMet) *100;
            label1.Text = percentage.ToString();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            simulation();        
        }
    }
}