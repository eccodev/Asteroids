using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    public ParticleSystem explosion;

    public float respawnTime = 3.0f;

    public float respawnInvulnerbilityTime = 3.0f;

    public int lives = 3;

    public int score = 0;
    public void AsteriodDestroyed(Asteroid asteriod)
    {
        this.explosion.transform.position = asteriod.transform.position;
        this.explosion.Play();

        if (asteriod.size < 0.75f)
        {
            this.score += 100;
        }
        else if (asteriod.size < 1.2f)
        {
            this.score += 50;
        }
        else
        {
            this.score += 25;
        }
    }
    public void PlayerDied()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

        this.lives--;

        if (this.lives == 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);
        }
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);

        Invoke(nameof(TurnOnCollisions), this.respawnInvulnerbilityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        this.lives = 3;
        this.score = 0;

        Invoke(nameof(Respawn), this.respawnTime);
    }

}