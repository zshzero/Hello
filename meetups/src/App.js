import Container from 'react-bootstrap/Container'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'

import Todo from "./Components/Todo";

function App() {
	return (
		<Container>
			<h1>My Todos</h1>

			<Row>
				<Col><Todo header="Task 1" /></Col>
				<Col><Todo header="Task 2" /></Col>
				<Col><Todo header="Task 3" /></Col>
			</Row>

		</Container>
	);
}

export default App;
