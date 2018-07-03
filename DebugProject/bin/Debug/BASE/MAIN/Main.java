import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.PriorityQueue;
import java.util.StringTokenizer;

class Process implements Comparable<Process>
{
    long StartTime;
    long FinishTime;

    public Process(long StartTime, long FinishTime) {
        this.StartTime = StartTime;
        this.FinishTime = FinishTime;
    }

    @Override
    public int compareTo(Process t) {
        if(FinishTime > t.FinishTime)
        {
            return 1;
        }
        else if(FinishTime < t.FinishTime)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
    
    
}
public class Main {

	public static void main(String[] args) throws IOException{
		InputReader ip = new InputReader(System.in);
                int n = ip.nextInt();   
                ArrayList<Process> list = new ArrayList<>();
                HashMap<Long, Integer> check = new HashMap<>();
                for(int i = 0; i <n; i++)
                {
                    Process p = new Process(ip.nextLong(), ip.nextLong());
                    list.add(p);
                    if(check.containsKey(p.StartTime))
                    {
                        check.computeIfPresent(p.StartTime,(t, u) -> u + 1);
                    }
                    else
                    {
                        check.put(p.StartTime, 1);
                    }
                }
                Collections.sort(list, (t1, t2)->{
                    if(t1.StartTime > t2.StartTime)
                    {
                        return 1;
                    }
                    else if(t1.StartTime < t2.StartTime)
                    {
                        return -1;
                    }
                    else
                    {
                        if(t1.FinishTime > t2.FinishTime)
                        {
                            return 1;
                        }
                        else if(t1.FinishTime < t2.FinishTime)
                        {
                            return -1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                });
                PriorityQueue<Process> queue = new PriorityQueue<>();
                long currentTime = 0;
                int i = 0;
                Process p = list.get(0);
                currentTime += p.StartTime - currentTime;
                int count1 = 1;
                while(count1 < check.get(currentTime)) // check the number of new processes come at the time
                        {
                i++;
                Process temp = list.get(i);
                queue.add(temp);   //add the new process to queue
                count1++;
                            
                }
              
                while(true) // processing
                {
                    if(i + 1 < n)
                    {
                        long temp = list.get(i + 1).StartTime - currentTime;
                        if(temp <= p.FinishTime)
                        {
                            p.FinishTime -= temp; // Times left of the process until finish
                            currentTime += temp; // Current Time
                        }
                        else
                        {
                            currentTime += p.FinishTime; // Current Time
                             p.FinishTime -= p.FinishTime; // Times left of the process until finish
                            
                            
                        }
                    }
                    else
                    {
                            currentTime += p.FinishTime; // Current Time
                            p.FinishTime -= p.FinishTime; // Times left of the process until finish
                            
                    }
                    if(p.FinishTime == 0) // if the process finish
                    {
                        if(queue.isEmpty()) // if no processes waiting
                        {
                            if(i < n - 1)
                            {
                               
                                    currentTime += (list.get(i+1).StartTime - currentTime);
                  
                            }
                            else
                            {
                                break;
                            }
                           
                        }
                        else 
                        {
                            p = queue.poll(); // set turn for another process
                        }
                    }
                    if(check.containsKey(currentTime)) // if new processes join at the current time
                    {
                        int count = 1;
                        while(count <= check.get(currentTime)) // check the number of new processes come at the time
                        {
                            i++;
                            Process temp = list.get(i);
                            if(p.FinishTime == 0)
                            {
                                p = list.get(i); 
                            }
                            else if(temp.FinishTime < p.FinishTime) // if new process have less time to finish 
                            {
                                queue.add(p);                   //then add the current process to queue
                                p = list.get(i);                //set turn for the new process    

                            }
                            else    
                            {
                                queue.add(temp);   //add the new process to queue
                            }
                            count++;
                        }
                        
                    }
                    
                }
                System.out.println(currentTime - 1);
while(true)
{
}
	}

	static class InputReader {
		StringTokenizer tokenizer;
		BufferedReader reader;
		String token;
		String temp;

		public InputReader(InputStream stream) {
			tokenizer = null;
			reader = new BufferedReader(new InputStreamReader(stream));
		}

		public InputReader(FileInputStream stream) {
			tokenizer = null;
			reader = new BufferedReader(new InputStreamReader(stream));
		}

		public String nextLine() throws IOException {
			return reader.readLine();
		}

		public String next() {
			while (tokenizer == null || !tokenizer.hasMoreTokens()) {
				try {
					if (temp != null) {
						tokenizer = new StringTokenizer(temp);
						temp = null;
					} else {
						tokenizer = new StringTokenizer(reader.readLine());
					}

				} catch (IOException e) {
				}
			}
			return tokenizer.nextToken();
		}

		public double nextDouble() {
			return Double.parseDouble(next());
		}

		public int nextInt() {
			return Integer.parseInt(next());
		}
                public float nextFloat()
                {
                    return Float.parseFloat(next());
                }
		public long nextLong() {
			return Long.parseLong(next());
		}
	}
}
