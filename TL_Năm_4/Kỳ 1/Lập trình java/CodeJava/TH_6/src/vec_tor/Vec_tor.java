package vec_tor;

import java.util.Iterator;
import java.util.Vector;
	public class Vec_tor {
		public static void main(String[] args) {
			Vector<Integer> vector = new Vector<>();
			for(int i = 1; i <= 10; i++)
				vector.addElement(i);

			for(int i = 0; i < vector.size(); i++)
				System.out.print(vector.get(i) + " ");

			System.out.println("\nDùng foreach:");
			for (Integer sn : vector) {
				System.out.print(sn + " ");
			}

			System.out.println("\nDùng Iterator:");
			for (Iterator<Integer> inter = 
					vector.iterator(); inter.hasNext();) {
				Integer sn = (Integer) inter.next();
				System.out.print(sn + " ");
			}
			System.out.println("\nGía trị tại ví trí 0 là :" + vector.elementAt(0));

			vector.removeAllElements();
			if (vector.isEmpty())
				System.out.println("\nVector rỗng");
			else
				System.out.println("\nVector không rỗng");
		}
}

