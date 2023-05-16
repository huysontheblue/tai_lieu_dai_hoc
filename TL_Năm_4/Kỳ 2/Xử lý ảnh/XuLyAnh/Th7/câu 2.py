# 2. Đọc ảnh và thực hiện các thao tác sau:
# - Tạo trackbar để lấy góc xoay của ảnh
# - Xoay ảnh sang trái với góc xoay lấy từ trackbar, tâm 
# xoay nằm ở giữa ảnh
import cv2
img =cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
def xoay(vitri):
    xoay.value = vitri
xoay.value =0
cv2.namedWindow('Xoayanh')
cv2.createTrackbar('cx','Xoayanh',0,150,xoay)
while(True):
    goc = xoay.value
    h,c = img.shape[:2]
    cx,cy =h/2,c/2
    M = cv2.getRotationMatrix2D((cx,cy), goc, 1)
    img1 = cv2.warpAffine(img,M,(c,h))
    cv2.imshow('Xoayanh',img1) 
    if cv2.waitKey(5) == ord(' '):
        break
cv2.destroyAllWindows()


