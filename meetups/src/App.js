import { Route, Routes } from "react-router-dom";
import { Container } from "react-bootstrap";

import AllMeetups from "./Pages/AllMeetups"
import NewMeetup from "./Pages/NewMeetup"
import Favorites from "./Pages/Favorites"
import MainNavigation from "./Components/Layout/MainNavigation"

export default () => {
	return (
		<>
			<MainNavigation />
			<Container fluid="md" className="md-center">
				<Routes>
					<Route path="/" element={<AllMeetups />} exact></Route>
					<Route path="/new" element={<NewMeetup />} ></Route>
					<Route path="/fav" element={<Favorites />} ></Route>
				</Routes>
			</Container>
		</>
	);
}
