import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.StringTokenizer;

class Vertex{
    char value;
    boolean visited;
    ArrayList<Integer> neighbors;
    public Vertex(char value) {
        this.value = value;
        visited = false;
        neighbors = new ArrayList<>();
    }
}
class Graph{
    Vertex[] vertices;
    public Graph(int n, int m) {
        vertices = new Vertex[n*m];
    }
    public void addEdges(Integer u, Integer v) {
        vertices[u].neighbors.add(v);
        vertices[v].neighbors.add(u);
    }
    public int dfs() {
        return dfs(0, 0);
    }
    public int dfs(Integer vertex, int count) {
        vertices[vertex].visited = true;
        for (Integer neighborVertex : vertices[vertex].neighbors) {
            if (vertices[neighborVertex].value == '1') {
                count = count + 1;
                continue;
            }
            if (vertices[neighborVertex].visited == false)
                count = dfs(neighborVertex, count);
        }
        return count;
    }
}
public class Main {
    public static void main(String[] args) {
        InputReader ip = new InputReader(System.in);
        int n = ip.nextInt();
        int m = ip.nextInt();
        //init the map
        char[][] map = new char[n + 2][m + 2];
        for(int i = 0; i < n + 2; i++)
            for(int j = 0; j < m + 2; j++)
                map[i][j] = '0';
        for (int i = 1; i <= n; i++) {
            String s = ip.next();
            for (int j = 1, t = 0; j <= m; j++, t++)
                map[i][j] = s.charAt(t);
        }   
        /*convert the map to graph and using dfs to find coastline*/
        //init graph
        Graph g = new Graph(n + 2, m + 2);
        //init vertex
        int vertex = 0;
        for (int i = 0; i < n + 2; i++) {
            for (int j = 0; j < m + 2; j++) {
                g.vertices[vertex] = new Vertex(map[i][j]);
                vertex++;
            }
        }  
        //init edges
        vertex = 0;
        for (int i = 0; i < n + 2; i++) {
            for (int j = 0; j < m + 2; j++) {
                if (j + 1 < m + 2)
                    g.addEdges(vertex, vertex + 1);
                if(i + 1 < n + 2)
                    g.addEdges(vertex, vertex + (m + 2));
                vertex++;
            }
        }
        //DFS   
        System.out.println(g.dfs());
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

        public long nextLong() {
            return Long.parseLong(next());
        }
    }
}
