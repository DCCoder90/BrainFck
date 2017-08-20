using BrainFuck;
using System;
using System.IO;
using System.Windows.Forms;

namespace BrainFck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void interpretButton_Click(object sender, EventArgs e)
        {
            Interpreter interpreter = new Interpreter();

            string source = inputBox.Text;

            string output = interpreter.Interpret(source);

            outputBox.Text = output;

            interpreter.Reset();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void loadFromFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog about = new AboutDialog();
            about.Show();
        }

        private void aboutLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://esolangs.org/wiki/Brainfuck");
        }

        private void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string name = saveFileDialog.FileName;
            File.WriteAllText(name, inputBox.Text);
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string name = openFileDialog.FileName;
            inputBox.Text = File.ReadAllText(name);
        }

        private void helloWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputBox.Text =
                "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.";
        }

        private void squareNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputBox.Text = "++++[>+++++<-]>[<+++++>-]+<+[    >[>+>+<<-]++>>[<<+>>-]>>>[-]++>[-]+    >>>+[[-]++++++>>>]<<<[[<++++++++<++>>-]+<.<[>-----]<]    <<[>>>>>[>>>[-]+++++++++<[>-<-]+++++++++>[-[<->-]+[<<<]]<[>+<-]>]<<-]<<-]";
        }

        private void fibbanociToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputBox.Text = "+++++++++++>+>>>>++++++++++++++++++++++++++++++++++++++++++++>++++++++++++++++++++++++++++++++<<<<<<[>[>>>>>>+>+<<<<<<<-]>>>>>>>[<<<<<<<+>>>>>>>-]<[>++++++++++[-<-[>>+>+<<<-]>>>[<<<+>>>-]+<[>[-]<[-]]>[<<[>>>+<<<-]>>[-]]<<]>>>[>>+>+<<< -]>>>[<<< +>>> -] +<[>[-] <[-]] >[<< +>>[-]] <<<<<<<]>>>>>[++++++++++++++++++++++++++++++++++++++++++++++++.[-]]++++++++++ <[->-<] > ++++++++++++++++++++++++++++++++++++++++++++++++.[-] <<<<<<<<<<<<[>>> +> +<<<< -] >>>>[<<<< +>>>> -] < -[>>.>.<<<[-]] <<[>> +> +<<< -] >>>[<<< +>>> -] <<[< +> -] >[< +> -] <<< -]";
        }
    }
}
