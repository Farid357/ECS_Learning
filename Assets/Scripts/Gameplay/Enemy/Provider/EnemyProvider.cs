using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;

namespace Game
{
    public class EnemyProvider : MonoProvider<EnemyComponent>
    {
        private void Update()
        {
            if (Entity.GetComponent<EnemyComponent>().Health > 0)
                return;
            
            Destroy(gameObject);
        }
    }
}