# gamedev-07-q2
Contains the second question (adding dramatic components): [gamedev-5780](https://github.com/erelsgl-at-ariel/gamedev-5780)

**Created by:**

[Chen Ostrovski](https://github.com/ChenOst)

[Enna Grigor](https://github.com/ennagrigor)

This is a game that consists an animated pig that is trying to get to the other side of the field and has to avoid colisions with dogs.
The pig has 3 chances of hitting a dog (if hits 3 times then the pig starts over). 
Once crossed the pig wins and has an option to play again.

<img src="https://github.com/ennagrigor/PigDogGame/blob/master/Screenshot_1.png" width=400>

## The Pig

The pig has the option of moving up, down, right, left.
The moving is done using the arrow keys and doing so activates the animation that matches the movement. 
- `up key` - moves the pig up.
- `down key` - moves the pig down
- `right key` - moves the pig right.
- `left key` - moves the key left.

This code shows how the animation is activated when the pig moves.

```C#
if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            animator.Play("Pig Walking");
        }
        else if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.DownArrow)))
        {
            animator.Play("pig walking upDown");
        }
        else
        {
            animator.Play("Idle");
        }
```
The pig also has borders so he can not go out of screen and is bounded within the game.
The borders are set with the transform component while checking if passed them.

```C#
if (transform.position.y >= 6)
        {
            transform.position = new Vector3(transform.position.x, 6, 0);
        }
        else if (transform.position.y <= -4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }
        if (transform.position.x >= 9.2f)
        {
            transform.position = new Vector3(9.2f, transform.position.y, 0);
        }
        else if (transform.position.x <= -9.2f)
        {
            transform.position = new Vector3(-9.2f, transform.position.y, 0);
        }
```
The pig has a damage function which checks if the player is dead and keeps track of lives, 
and if dead returns the pig back to the beginning and starts the count over.

```C#
public void Damage()
    {
            _lives -= 1;
            // check if the player is dead
            if (_lives < 1)
            {
                //Starts over from the begining with 3 lives
                _lives = 3;
                transform.position = new Vector3(0, -3.99f, 0);
            }
        }
```

## The Dogs

Rotate an Object. 
The user can add his own values to:
- `Position x, y, z` - Determine how the object will rotate on each axis.
- `Speed` - The speed of the rotation.

<img src="Images/q2.png" width=400>

## The Finish Line

Increases and decreases the ball gradually.
The user can add his own values to:
- `Max size` - The maximum size the ball can reach.
- `Min size` - The minimum size the ball can reach.
- `Speed` - The speed at which the ball is decreasing and increasing.

<img src="Images/q3.1.png" width=400>  <img src="Images/q3.2.png" width=400>

## Animation 

Moves the ball in a circular form.
In order to move the ball around you can use the arrow keys (<- and ->)
The user can add his own values to:
- `Speed` - Determine the speed of the movement.
- `Radius` - The distance between the current x position to the center of the circle.
(The center of the circle is positionX + radius).

## Audio

<img src="Images/q4.1.png" width=400> <img src="Images/q4.2.png" width=400>
