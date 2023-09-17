from math import sqrt

def prod_non_zero_diag_non_vect(x):
    res = 1
    for i in range(min(len(x), len(x[0]))):
        if x[i][i] != 0:
            res *= x[i][i]
    return res

def are_multisets_equal_non_vect(x, y):
    return (set(x) == set(y))

def max_after_zero_non_vect(x):
    mx = 0
    flag = 0
    for i in range(1, len(x)):
        if x[i - 1] == 0:
            if flag == 0: mx, flag = x[i], 1
            else: mx = max(mx, x[i])
    return mx

def convert_image_non_vect(img, coeff):
    res = list()
    for i in range(len(img)):
        res2 = list()
        for j in range(len(img[0])):
            s = 0
            for q in range(len(coeff)):
                s += img[i][j][q] * coeff[q]
            res2.append(s)
        res.append(res2)
    return res

def run_length_encoding_non_vect(x):
    a, b = [x[0]], list()
    cnt = 1
    for i in range(1, len(x)):
        if x[i - 1] != x[i]:
            a.append(x[i])
            b.append(cnt)
            cnt = 0
        cnt += 1
    b.append(cnt)
    return (a, b)

def pairwise_distance_non_vect(x, y):
    res = list()
    for i in range(len(x)):
        res2 = list()
        for j in range(len(y)):
            s = 0
            for q in range(len(x[0])):
                s += (x[i][q] - y[j][q]) ** 2
            s = sqrt(s)
            res2.append(s)
        res.append(res2)
    return res
