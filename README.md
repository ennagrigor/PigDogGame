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
The pig also has a win function that only destroys the object of pig (once the player wins):

```C#
public void Win()
        {
            Destroy(this.gameObject);
        }
```

## The Dogs

The dogs are prefabs that make up the enemy in this game.
They are also an animation that goes across the screen and reappears in loops.
once the pig hits the dog - the dog turns into an explosion to indicate that it has been hit and triggers a bark audio.

The borders are set in the code like this and activates the dog animation once it returns to the beginning:

```C#
if (transform.position.x >= 10)
        {
            transform.position = new Vector3(-10, transform.position.y, 0);
            animator.Play("Dog Run");
        }
```

The dog is also a trigger (when the pig colides with the dog) that activates the damage function in pig, 
changes anitation to explosion and plays the barking audio:

```C#
private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerPig")
        {
            other.transform.GetComponent<Mover>().Damage();
            animator = GetComponent<Animator>();
            animator.Play("Explosion");
            audioSource.Play(); 
        }
    }
```

<img src="Ihttps://github.com/ennagrigor/PigDogGame/blob/master/Screenshot_3.png" width=400>

## Obsticles

There are two types of obsticles: bushes and fences. 
the pig can not move across them and has to go around.
There are also flowers in the game but the do not act like obsticals - the pig can go across them.


## The Finish Line

The finish line is an object that has a trigger.
Once the pig colides with it - it triggers a canvas object and audio to let the player know they won.
In the code it is done like this:

```C#
private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerPig")
        {
            _YouWonText.gameObject.SetActive(true);         // activates win text
            other.transform.GetComponent<Mover>().Win();    // destroys player pig
            audioSource.Play();                             // activates audio
        } 
    }
```

In the finish line there is also an option to start over the game:

```C#
if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
```

<img src="https://github.com/ennagrigor/PigDogGame/blob/master/Screenshot_2.png" width=400>  

## Animation 

There are 3 main animation that are featured in the game:

### The pig (also rotated to make the pig go up/down):
<img src="https://github.com/ennagrigor/PigDogGame/blob/master/Screenshot_5.png" width=400>

### The dog:
<img src="https://github.com/ennagrigor/PigDogGame/blob/master/Screenshot_6.png" width=400>

### The Explosion:
<img src="https://github.com/ennagrigor/PigDogGame/blob/master/Screenshot_4.png" width=400>

## Audio

The game has 3 types of audio components:
- The background music: plays throughout the game.
- The barking: plays when pig hits a dog.
- The cheering: plays when player won.

## Link to ITCH.IO
[Pig and Dog game](https://ennagrigor.itch.io/pigdoggame)

