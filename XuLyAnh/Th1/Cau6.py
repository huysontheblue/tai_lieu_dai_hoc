#Hiện nhiều hình ảnh với thư viện matplotlib. Hiện ra 4 ảnh trên một cửa sổ

#import thư viện
import cv2
from matplotlib import pyplot as plt
  
#kích thước khung nhìn
fig = plt.figure(figsize=(8, 11))
  
# thiết lập giá trị cho các biến hàng và cột
rows = 1
columns = 4
  
# đọc ảnh 
img1 = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")

  
# Thêm một ô phụ ở vị trí đầu tiên
fig.add_subplot(rows, columns, 1)
  
# hiển thị hình ảnh
plt.imshow(img1)
plt.axis('off')
plt.title("1")
  
# Thêm một ô phụ ở vị trí thứ 2
fig.add_subplot(rows, columns, 2)
  
# hiển thị hình ảnh
plt.imshow(img1)
plt.axis('off')
plt.title("2")
  
# Thêm một ô phụ ở vị trí thứ 3
fig.add_subplot(rows, columns, 3)
  
# hiển thị hình ảnh
plt.imshow(img1)
plt.axis('off')
plt.title("3")
  
# Thêm một ô phụ ở vị trí thứ 4
fig.add_subplot(rows, columns, 4)
  
# hiển thị hình ảnh
plt.imshow(img1)
plt.axis('off')
plt.title("4")
