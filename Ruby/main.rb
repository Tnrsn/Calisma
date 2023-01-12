@Do = File.open("dosya.txt", "w")
# ID
# name
# surname
# age

@Do.write("6\n")
@Do.write("Ali\n")
@Do.write("Ercebi\n")
@Do.write("25")

@Do.close()