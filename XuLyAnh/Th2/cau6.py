#  Xoay ảnh 1 góc tùy ý lấy từ trackbar.
import cv2

img =cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
def get_goc(vitri):
 get_goc.value = vitri
get_goc.value =0
cv2.namedWindow('Xoayanh')
cv2.createTrackbar('cx','Xoayanh',0,360,get_goc)
while(True):
 goc = get_goc.value
 h,c = img.shape[:2]
 # lấy tâm xoay ở giữa
 cx,cy =h/2,c/2
 # hàm xoay ảnh
 M = cv2.getRotationMatrix2D((cx,cy), goc, 1)
 img1 = cv2.warpAffine(img,M,(c,h))
 cv2.imshow('Xoayanh',img1) 
 if cv2.waitKey(5) == ord('q'):
     break
cv2.destroyAllWindows()
