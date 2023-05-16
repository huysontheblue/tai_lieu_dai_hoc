#Trackbar tương phản, độ sáng
import cv2
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
def changea(x):
    changea.value = x
changea.value = 0
def changeb(x):
    changeb.value = x
changeb.value = 0

cv2.namedWindow('xulyanh')
cv2.createTrackbar('tuong phan','xulyanh', 1, 15, changea)
cv2.createTrackbar('do sang','xulyanh', 0, 50, changeb)

while(True):
    alpha = changea.value
    beta = changeb.value
    img1 = cv2.convertScaleAbs(img,alpha = alpha, beta = beta)
    cv2.imshow('xulyanh',img1)
    if cv2.waitKey(5) == ord ('q'): break 
cv2.destroyAllWindows()


