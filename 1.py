n = int(input())
al = ['a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z']
f = False
right_word = ['0']*n

for att in range(26):
    word = al[att] *n
    print(word)
    shiko_mas = input().split()
    shiko_answ = shiko_mas[0]
    if shiko_answ == "Yes":
        break
    else:
        shiko_n = int(shiko_mas[1])


        for i in range(shiko_n):
            right_word[int(shiko_mas[i+2])-1] = al[att]

str_a = ''.join(right_word)
print(str_a)
answ = input()