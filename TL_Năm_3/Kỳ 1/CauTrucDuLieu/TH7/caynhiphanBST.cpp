#include<iostream>
#define SPACE 10
 
using namespace std;
 
class TreeNode {
  public:
    int value;
  TreeNode * left;
  TreeNode * right;
 
  TreeNode() {
    value = 0;
    left = NULL;
    right = NULL;
  }
  TreeNode(int v) {
    value = v;
    left = NULL;
    right = NULL;
  }
};
 
class BST {
  public:
    TreeNode * root;
  BST() {
    root = NULL;
  }
  bool isTreeEmpty() {
    if (root == NULL) {
      return true;
    } else {
      return false;
    }
  }
 // Chèn (Them) phan tu
  void insertNode(TreeNode * new_node) {
    if (root == NULL) {
      root = new_node;
      cout << "gia tri duoc chen lam nut goc!" << endl;
    } else {
      TreeNode * temp = root;
      while (temp != NULL) {
        if (new_node -> value == temp -> value) {
          cout << "Gia tri da ton tai," <<
            "Chen gia tri khac!" << endl;
          return;
        } else if ((new_node -> value < temp -> value) && (temp -> left == NULL)) {
          temp -> left = new_node;
          cout << "Da chen gia tri vao ben trai!" << endl;
          break;
        } else if (new_node -> value < temp -> value) {
          temp = temp -> left;
        } else if ((new_node -> value > temp -> value) && (temp -> right == NULL)) {
          temp -> right = new_node;
          cout << "Da chen gia tri vao ben phai!" << endl;
          break;
        } else {
          temp = temp -> right;
        }
      }
    }
  }
 // hàm in BST 2D
  void print2D(TreeNode * r, int space) {
    if (r == NULL) 
      return;
    space += SPACE; // Tang khoang cach giua cac cap do 2  2
    print2D(r -> right, space);  
    cout << endl;
    for (int i = SPACE; i < space; i++)
      cout << " ";  
    cout << r -> value << "\n"; 
    print2D(r -> left, space); 
  }
 // ham in duyet NLR duyet truoc
void NLR(TreeNode * r) //(goc , trai, phai) 
  {
    if (r == NULL)
      return;
    
    cout << r -> value << " ";
    
    NLR(r -> left);
    
    NLR(r -> right);
  }
 // ham duyet  LNR  giua
void LNR(TreeNode * r) 
  {
    if (r == NULL)
      return;
    LNR(r -> left);
    cout << r -> value << " ";
    LNR(r -> right);
  }
  // duyet LRN sau
void LRN(TreeNode * r) //(trai, phai, goc)
  {
    if (r == NULL)
      return;
    LRN(r -> left); 
    LRN(r -> right);
    cout << r -> value << " ";
  }
  
//node gia tri nho nhat
int Min(TreeNode * r) {
   if( r-> left == NULL)
    {
        return r-> value;
    }
    return Min(r-> left);
}
//nut lon nhat trong cay
int Max(TreeNode * r) {
   if( r-> right == NULL)
    {
        return r->value;
    }
      return Max(r->right);
}
// nut cay * tim liem lap lai
  TreeNode * iterativeSearch(int v) {
    if (root == NULL) {
      return root;
    } else {
      TreeNode * temp = root;
      while (temp != NULL) {
        if (v == temp -> value) {
          return temp;
        } else if (v < temp -> value) {
          temp = temp -> left;
        } else {
          temp = temp -> right;
        }
      }
      return NULL;
    }
  }
// nut cay * tim kiem de quy 
TreeNode * recursiveSearch(TreeNode * r, int val) {
    if (r == NULL || r -> value == val)
      return r;
 
    else if (val < r -> value)
      return recursiveSearch(r -> left, val);
 
    else
      return recursiveSearch(r -> right, val);
  }
 // chieu cao cua cay
int height(TreeNode * r) {
    if (r == NULL)
      return -1;
    else {

      int lheight = height(r -> left);
      int rheight = height(r -> right);
 
      if (lheight > rheight)
        return (lheight + 1);
      else return (rheight + 1);
    }
  }
 
// in cap do da cho
  void printGivenLevel(TreeNode * r, int level) {
    if (r == NULL)
      return;
    else if (level == 0)
      cout << r -> value << " ";
    else // level > 0  
    {
      printGivenLevel(r -> left, level - 1);
      printGivenLevel(r -> right, level - 1);
    }
  }
  
  void printLevelOrderBFS(TreeNode * r) {
    int h = height(r);
    for (int i = 0; i <= h; i++)
      printGivenLevel(r, i);
  }
 
  TreeNode * minValueNode(TreeNode * node) {
    TreeNode * current = node;
    /* lap xuong de tim la ngoai cung ben trai */
    while (current -> left != NULL) {
      current = current -> left;
    }
    return current;
  }
 
  TreeNode * deleteNode(TreeNode * r, int v) {
    if (r == NULL) {
      return NULL;
    }
    // Neu key can xoa < khoa cua goc
    // thi no nam ben trai
    else if (v < r -> value) {
      r -> left = deleteNode(r -> left, v);
    }
    // Neu key can xoa > khoa cua goc, 
    // Thi no nam ben phai
    else if (v > r -> value) {
      r -> right = deleteNode(r -> right, v);
    }
    // Neu key giong voi khoa goc, thi la nut se bi xoa 
    else {
      // Nut chi co mot nut con hoac khong co nut con
      if (r -> left == NULL) {
        TreeNode * temp = r -> right;
        delete r;
        return temp;
      } else if (r -> right == NULL) {
        TreeNode * temp = r -> left;
        delete r;
        return temp;
      } else {
         
        TreeNode * temp = minValueNode(r -> right);
        r -> value = temp -> value;
		r -> right = deleteNode(r -> right, temp -> value);
        //deleteNode(r->right, temp->value); 
      }
    }
    return r;
  }
 
};
 
int main() {
  BST obj;
  int option, val;
  int r;
 
  do {
    cout << "--------------MENU--------------" << endl;
    cout << "1. Them nut" << endl;
    cout << "2. Tim kiem nut " << endl;
    cout << "3. Xoa nut" << endl;
    cout << "4. In gia tri BST" << endl;
    cout << "5. Chieu cao cua cay" << endl;
    cout << "6. Duyet truoc NLR " << endl;
    cout << "7. Duyet giua LNR " << endl;
    cout << "8. Duyet sau LRN " << endl;
    cout << "9. Tim NODE Min" << endl;
    cout << "10. Tim NODE Max " << endl;
    cout << "11. Xoa man hinh" << endl;
    cout << "0. Thoat" << endl;
 
    cin >> option;
    TreeNode * new_node = new TreeNode();
 
    switch (option) {
    case 0:
      break;
    case 1:
      cout << "THEM" << endl;
      cout << "Nhap gia tri cua nut cay de THEM vao BST: ";
      cin >> val;
      new_node -> value = val;
      obj.insertNode(new_node);
      cout << endl;
      break;
    case 2:
      cout << "TIM KIEM" << endl;
      cout << "Nhap gia tri cua nut cay de TIM KIEM trong BST: ";
      cin >> val;
      //new_node = obj.iterativeSearch(val);
      new_node = obj.recursiveSearch(obj.root, val);
      if (new_node != NULL) {
        cout << "Gia tri duoc tim thay" << endl;
      } else {
        cout << "Khong tim thay gia tri" << endl;
      }
      break;
    case 3:
      cout << "XOA" << endl;
      cout << "Nhap GIA TRI cua NUT CAY de XOA trong BST: ";
      cin >> val;
      new_node = obj.iterativeSearch(val);
      if (new_node != NULL) {
        obj.deleteNode(obj.root, val);
        cout << "Gia tri duoc tim thay" << endl;
      } else {
        cout << "Khong tim thay gia tri" << endl;
      }
      break;
    case 4:
      cout << "IN 2D: " << endl;
      obj.print2D(obj.root, 5);
      cout << endl;
      cout << "Thu thu cap do in BFS: \n";
      obj.printLevelOrderBFS(obj.root);
      cout << endl;
      break;
    case 5:
      cout << "CHIEU CAO CAY" << endl;
      cout << "Chieu cao : " << obj.height(obj.root) << endl;
      break;
    case 6: 
      cout << " NLR: " ;
	  obj.NLR(obj.root);
	  cout << endl;
      break;
    case 7:
	  cout << " LNR: " ;
	  obj.LNR(obj.root);
	  cout << endl; 
    case 8:
      cout << " LRN: " ;
	  obj.LRN(obj.root);
	  cout << endl;
      break;
    case 9:
	  cout << "IN MIN: ";
	  obj.Min(obj.root); 
	  cout << endl;
	case 10:
	  cout << "IN MAX: ";
	  obj.Max(obj.root); 
	  cout << endl;   
    case 11:
      system("cls");
      break;
    default:
      cout << " Nhap so tuy chon thich hop" << endl;
    }
 
  } while (option != 0);
 
  return 0;
}
