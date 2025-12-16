"""--------------------------------------------------------

Script that we used to create the collision data of the map

--------------------------------------------------------"""

from PIL import Image

COLLISION_TAB_SIZE = 10 
COLLISION_RECT_SIZE = 126
NOMBRE_IMAGES = 9
NAME = "MapCollision"

Image.MAX_IMAGE_PIXELS = None

def Map():
    print("public static bool[,] MapColliders = new bool[,]")

    # Ouvrir l'image
    img = Image.open(f'{NAME}.png')

    # Recupère la taille
    w, h = img.size

    # On détermine le nombre de tile
    w = round(w / COLLISION_RECT_SIZE)
    h = round(h / COLLISION_RECT_SIZE)

    # Tableau des collisions
    collisions = [[0 for i in range(w)] for j in range(h)]

    for y in range(h):
        for x in range(w):
            # On récupère la position que l'on veut check
            centerW = (COLLISION_RECT_SIZE / 2) + x * COLLISION_RECT_SIZE
            centerH = (COLLISION_RECT_SIZE / 2) + y * COLLISION_RECT_SIZE

            # Check si pixel est rouge ou pas pour mettre les collisions dans le tableau
            r, g, b, a = img.getpixel((centerW,centerH))
            # J'ai mis 200 pour eviter erreur si seulement 254 ou moins
            if r > 200:
                collisions[y][x] = 1
            elif g > 200:
                collisions[y][x] = 2
            else :
                collisions[y][x] = 0
    print("{")
    l = 1
    for row in collisions:
        if  l == h :
            print("  {" + ", ".join(map(str, row)) + "}")
        else : 
            print("  {" + ", ".join(map(str, row)) + "},")
        l += 1
    print("};")

Map()