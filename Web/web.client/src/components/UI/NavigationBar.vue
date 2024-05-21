<template>
	<div class="navbar">
		<div class="content">
			<div @click="$router.push('/')" class="navbar__brand">
				<div>Платформа</div>
				<div>роботизации</div></div>
			<div class="navbar__btns">
				<my-button style="margin-left: 15px" @click="$router.push('/workflows/')">Процессы</my-button>
				<my-button style="margin-left: 15px" @click="$router.push('/tasks/')">Задачи</my-button>
			</div>
		</div>
	</div>
</template>

<script>
export default {

}
</script>

<style scoped>
.navbar {
	height: 70px;
	background-color: lightgray;
	box-shadow: 0px 1px 3px gray;
	display: flex;
	align-items: center;
	border-radius: 10px;
}

.navbar__brand {
	display: flex;
	flex-direction: column;
	border: 1px solid teal;
	border-radius: 5px;
	padding: 7px;
}

.navbar__btns {
	margin-left: auto;
}

.content {
	width: 900px;
	margin: 0 auto;
	display: flex;
	align-items: center;
	padding: 0 15px;
}

</style>