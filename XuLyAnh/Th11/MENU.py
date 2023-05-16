def menu():
    print("[0] Âm bản")
    print("[1] Tương phản")
    print("[2] Độ sáng")
    print("[3] Xoay phải")
    print("[4] Xoay trái")
    print("[5] Phân ngưỡng Otsu")
    print("[6] Contours")
    print("[7] Histogram")
    print("[8] Lưu ảnh")
    print("[9] Thoát")
option = int(input('Lựa chọn của bạn: ')) 
if option == 0:
    import cv2
    img =cv2.imread('E:\\1.jpg',0)
    def get_nguong(vitri):
        get_nguong.value = vitri
    get_nguong.value =127
    cv2.namedWindow('Nhiphan')
    cv2.createTrackbar('dentrang','Nhiphan',127,200,get_nguong)
    while(True):
        nguong = get_nguong.value
        ret,anh = cv2.threshold(img,nguong,255,cv2.THRESH_BINARY)
        neg = 255 - img
        cv2.imshow('Nhiphan',anh)
        cv2.imshow('Amban',neg)
        if cv2.waitKey(5) == ord(' '):
            break
    cv2.imwrite('E:\\amban.jpg',neg)
    cv2.waitKey(0)
    cv2.destroyAllWindows()
elif option == 1:
    import cv2
    img = cv2.imread('E:\\1.jpg')
    a = int(input('Nhap tuong phan: '))
    hien = cv2.convertScaleAbs(img,10,a)
    cv2.imshow('Trackbar',hien)
    cv2.waitKey(0)
    cv2.destroyAllWindows()
elif option == 2:
    import cv2
    img = cv2.imread('E:\\1.jpg')
    a = int(input('Nhập độ sáng: '))
    hien = cv2.convertScaleAbs(img,a/10,3)
    cv2.imshow('Trackbar',hien)
    cv2.waitKey(0)
    cv2.destroyAllWindows()
elif option == 3:
    import cv2
    import numpy as np
    img =cv2.imread('E:\\1.jpg')
    def get_goc(vitri):
        get_goc.value = vitri
    get_goc.value =0
    cv2.namedWindow('Xoayanh')
    cv2.createTrackbar('cx','Xoayanh',0,90,get_goc)
    while(True):
        goc = get_goc.value
        h,c = img.shape[:2]
        cx,cy =h/2,c/2
        M = cv2.getRotationMatrix2D((cx,cy), goc, 1)
        img1 = cv2.warpAffine(img,M,(c,h))
        cv2.imshow('Xoayanh',img1) 
        if cv2.waitKey(5) == ord(' '):
            break
    cv2.destroyAllWindows()
elif option == 4:
    import cv2
    import numpy as np
    img =cv2.imread('E:\\1.jpg')
    def get_goc(vitri):
        get_goc.value = vitri
    get_goc.value =0
    cv2.namedWindow('Xoayanh')
    cv2.createTrackbar('cx','Xoayanh',0,90,get_goc)
    while(True):
        goc = get_goc.value
        h,c = img.shape[:2]
        cx,cy =h/2,c/2
        M = cv2.getRotationMatrix2D((cx,cy), -goc, 1)
        img1 = cv2.warpAffine(img,M,(c,h))
        cv2.imshow('Xoayanh',img1) 
        if cv2.waitKey(5) == ord(' '):
            break
    cv2.destroyAllWindows()
elif option == 5:
    import cv2         
    import numpy as np   
    img = cv2.imread("E:\\ly.jpg",0)
    cv2.GaussianBlur(img, (5,5), 0)
    ret, nguong = cv2.threshold(img, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)     
    cv2.imshow('Otsu Threshold', nguong)  
    cv2.waitKey(0) 
    cv2.destroyAllWindows()   
elif option == 6:
    import cv2
    import numpy as np
    img = cv2.imread("E:\\hinh.jpg")
    cv2.GaussianBlur(img, (5,5), 0)
    cv2.imshow('bd', img)
    cn = cv2.Canny(img, 30, 200)
    #danh sách contour,danh sách vecto= (ảnh đầu vào, kiểu trích xuất, phương pháp)
    contours, hierarchy = cv2.findContours(cn, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_NONE)
    cv2.drawContours(img, contours, -1, (0, 255, 0), 3)
    cv2.imshow('Contours', img)
    cv2.waitKey(0)
    cv2.destroyAllWindows()
elif option == 7:
    import cv2
    from matplotlib import pyplot as plt
    img =cv2.imread('E:\\1.jpg',0)
    plt.subplot(221),plt.imshow(img),plt.title('Anh ban dau')
    plt.subplot(222),plt.title('Histogram1'),plt.hist(img)
    cv2.waitKey(0)
    cv2.destroyAllWindows()
elif option == 8: 
    import cv2
    img =cv2.imread('E:\\1.jpg')
    cv2.imwrite('E:\\thaithihuongly.jpg', img)
elif option == 9:
    exit()
else:
    print('Tùy chọn không hợp lệ. Vui lòng nhập một số từ 1 đến 10.')