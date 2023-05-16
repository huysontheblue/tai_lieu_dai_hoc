
import cv2
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg",0)

# Ảnh xám
cv2.imshow("Hien anh xam",img)
cv2.waitKey(5000)
cv2.destroyAllWindows()

# Ảnh nhị phân
ret, binary_img = cv2.threshold(img, 128, 255, cv2.THRESH_BINARY)
# chuyển dổi sag dạng nhị phân 
bw = cv2.threshold(img, 128, 255, cv2.THRESH_BINARY) 
cv2.imshow("Hien anh nhi phan", binary_img)
cv2.waitKey(0)
cv2.destroyAllWindows()
