namespace Xde.Software.Data;

/// <summary>
/// Entity
/// </summary>
/// <typeparam name="TEntity">
/// TODO:Entity class to which this one relates (the same entity, "partition" or
/// other kind of relation).
/// </typeparam>
/// <remarks>
/// TODO:Consider as a marker interface to classes those references
/// <typeparamref name="TEntity"/>. This way we can clearly understand that some
/// CreateUserRequest relates to the User entity and perform relevant code
/// generation.
/// </remarks>
public interface IEntity<TEntity>
{

}
