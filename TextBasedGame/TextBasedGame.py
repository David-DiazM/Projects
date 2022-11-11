#David Diaz
def main():
    print('These are the instructions')

if __name__ == '__main__':
    main()
    rooms = {
        'Science Room': {'Name': 'Science Room', 'go North': "Teacher's Lounge", 'go South': 'Classroom',
                         'go East': "Principal’s Office", 'go West': 'Cafeteria', 'Item': ' '},
        "Teacher's Lounge": {'Name': "Teacher's Lounge", 'go South': 'Science Room', 'go East': 'Bathroom',
                             'Item': 'Teacher Roster'},
        'Cafeteria': {'Name': 'Cafeteria', 'go East': 'Science Room', 'Item': 'Food'},
        'Classroom': {'Name': 'Classroom', 'go North': 'Science Room', 'go East': 'Locker Room',
                      'Item': 'Murder Weapon'},
        'Locker Room': {'Name': 'Locker Room', 'go West': 'Classroom', 'Item': 'Clothes'},
        "Principal’s Office": {'Name': "Principal's Office", 'go West': 'Science Room', 'go North': 'Storage Room',
                               'Item': 'Security Footage'},
        'Storage Room': {'Name': 'Storage Room', 'go South': "Principal’s Office", 'Item': 'Equipment'},
        'Bathroom': {'Name': 'Bathroom', 'go West': "Teacher's Lounge", 'Item': 'Spirit of Child'}
    }

    #Game Instructions and Main Menu
    print('Welcome to the Murder Mystery!')
    directions = 'go South', 'go North', 'go East', 'go West'
    print('Move commands: go South, go North, go East, go West')
    itemsCommand = 'get Food', 'get Murder Weapon', 'get Clothes', 'get Security Footage', 'get Equipment',\
                   'get Teacher Roster'
    items = ['Food', 'Murder Weapon', 'Clothes', 'Security Footage', 'Equipment',
             'Teacher Roster']
    print('Collect all 6 items to solve the mystery before you reach the spirit or be killed!')
    print('Add to Inventory: get "item name" ')
    border = '-'
    print(border * 60)

    currentRoom = rooms['Science Room']
    currentInventory = []

    while True:
        #Current Room and Command Input
        print('You are in the {}'.format(currentRoom['Name']))
        #Display Current Inventory and Item in Room
        if currentRoom == rooms['Science Room']:
            print('Inventory: {}'.format(currentInventory))
        else:
            if currentRoom['Item'] not in currentInventory:
                print('You see {}'.format(currentRoom['Item']))
            print('Inventory: {}'.format(currentInventory))
        command = input('Enter your move:\n')

        #Proper Command Input
        if command in directions:
            if command in currentRoom:
                currentRoom = rooms[currentRoom[command]]
                print(border * 40)
            #Improper Command Movement
            else:
                print("You can't go that way!")
                print(border * 40)
        #Add Item to Inventory
        elif command in itemsCommand:
            if currentRoom['Item'] in currentInventory:
                print('You cannot add that!')
                print(border * 40)
            else:
                currentInventory.append(currentRoom['Item'])
                print(border * 40)
        # Invalid Input Command
        else:
            print('Invalid input!')
            print(border * 40)

        #Game Winning or Losing Function
        if (currentRoom == rooms['Bathroom']) and (currentInventory == items):
            print('Congrats! You have solved my murder and can bring me justice. Thank you!')
            break
        elif (currentRoom == rooms['Bathroom']) and (currentInventory != items):
            print('You have not found everything! Time to die!')
            break