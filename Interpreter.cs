using System;

namespace BrainFuck
{
    class Interpreter
    {
        private static readonly int BUFSIZE = 65535;
        private int[] buf = new int[BUFSIZE];
        private int ptr { get; set; }
        private bool echo { get; set; }

        public Interpreter()
        {
            this.ptr = 0;
            this.Reset();
        }

        public void Reset()
        {
            Array.Clear(this.buf, 0, this.buf.Length);
        }

        public string Interpret(string s)
        {

            string output = "";
            int i = 0;
            int right = s.Length;
            while (i < right)
            {
                switch (s[i])
                {
                    case '>':
                        {
                            this.ptr++;
                            if (this.ptr >= BUFSIZE)
                            {
                                this.ptr = 0;
                            }
                            break;
                        }
                    case '<':
                        {
                            this.ptr--;
                            if (this.ptr < 0)
                            {
                                this.ptr = BUFSIZE - 1;
                            }
                            break;
                        }
                    case '.':
                        {
                            output += (char)this.buf[this.ptr];
                            break;
                        }
                    case '+':
                        {
                            this.buf[this.ptr]++;
                            break;
                        }
                    case '-':
                        {
                            this.buf[this.ptr]--;
                            break;
                        }
                    case '[':
                        {
                            if (this.buf[this.ptr] == 0)
                            {
                                int loop = 1;
                                while (loop > 0)
                                {
                                    i++;
                                    char c = s[i];
                                    if (c == '[')
                                    {
                                        loop++;
                                    }
                                    else
                                    if (c == ']')
                                    {
                                        loop--;
                                    }
                                }
                            }
                            break;
                        }
                    case ']':
                        {
                            int loop = 1;
                            while (loop > 0)
                            {
                                i--;
                                char c = s[i];
                                if (c == '[')
                                {
                                    loop--;
                                }
                                else
                                if (c == ']')
                                {
                                    loop++;
                                }
                            }
                            i--;
                            break;
                        }
                }
                i++;
            }

            return output;
        }
    }
}