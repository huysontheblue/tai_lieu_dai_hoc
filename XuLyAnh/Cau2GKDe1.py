import cv2
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
cv2.namedWindow("display")
def get_x(x):
    get_x.value = x
get_x.value = 0
def get_y(y):
    get_y.value = y
get_y.value = 0
def get_a(a):
    get_a.value = a
get_a.value = 0
cv2.createTrackbar("x","display",1,100,get_x)
cv2.createTrackbar("y","display",1,100,get_y)
cv2.createTrackbar("a","display",1,10,get_a)
while(True):
    x = get_x.value
    y = get_y.value
    a = get_a.value
    img1 = cv2.convertScaleAbs(img, alpha = a, beta = 1)
    img2 = cv2.blur(img1,(x,y))
    cv2.imshow("display", img2)
    if cv2.waitKey(5) == ord("q"):
        break
cv2.destroyAllWindows()