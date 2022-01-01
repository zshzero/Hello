import { useContext } from 'react';

import FavoritesContext from '../Store/favorites-context';
import MeetupList from '../Components/meetups/MeetupList';

export default () => {
    const favoritesCtx = useContext(FavoritesContext);

    let content;

    if (favoritesCtx.totalFavorites === 0) {
        content = <p>You got no favorites yet. Start adding some?</p>;
    } else {
        content = <MeetupList meetups={favoritesCtx.favorites} />;
    }

    return (
        <section>
            <h1>My Favorites</h1>
            {content}
        </section>
    )
}