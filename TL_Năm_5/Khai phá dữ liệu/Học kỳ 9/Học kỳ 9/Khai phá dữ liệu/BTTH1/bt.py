import pandas as pd
import numpy as np
import matplotlib.pyplot as plt

df = pd.read_csv('data.csv')

# df.loc[7, 'Duration'] = 45

# for x in df.index:
#   if df.loc[x, "Duration"] > 120:
#     df.loc[x, "Duration"] = 120


# df.duplicated()
# # df.drop_duplicates(inplace = True) 
# print(df)

# #Vẽ biểu đồ
# df.plot() 
# plt.show()

# #Vẽ dữ liệu theo các tọa độ với ‘scatter’ 
# df.plot(kind = 'scatter', x = 'Duration', y = 'Calories') 
# plt.show() 


# #Vẽ biểu đồ với ‘hist’ 
# df["Duration"].plot(kind = 'hist') 
# plt.show()


# #Using Z score = (Observation — Mean)/Standard Deviation
# #z = (X — μ) / σ
# median = df.fillna(value=df.median())
# print(median)

dataset= [10, 12, 12, 13, 12, 11, 14, 13, 15, 10, 10, 12, 100, 10, 11, 99]
outliers = []

def detect_outlier (data_1) :
    threshold = 3
    mean_1 = np.mean(data_1)
    std_1 = np.std(data_1)
    for y in data_1:
        z_score = (y - mean_1) / std_1
        if np.abs(z_score) > threshold:
            outliers.append(y)
    return outliers

outlier_datapoints = detect_outlier(dataset)
print('data set: ', dataset)
plt.plot(dataset)
plt.show( )
print('outlier_datapoints of data set: ', outlier_datapoints)