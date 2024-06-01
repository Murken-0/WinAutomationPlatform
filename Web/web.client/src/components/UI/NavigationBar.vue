<template>
	<div class="navbar">
		<div
			class="navbar__brand"
			@click="$router.push('/workflows')">
			<div><strong>Платформа</strong></div>
			<div><strong>роботизации</strong></div>
		</div>
		<div class="navbar__btns">
			<my-button style="margin-left: 15px" @click="$router.push('/workflows/')">Процессы</my-button>
			<my-button style="margin-left: 15px" @click="$router.push('/tasks/')">Задачи</my-button>
		</div>
	</div>
</template>

<script>
import MyButton from "@/components/UI/MyButton.vue";

export default {
	components: {MyButton}

}
</script>

<style scoped>
.navbar {
	height: 70px;
	background-color: lightgray;
	box-shadow: 0 1px 3px gray;
	display: flex;
	align-items: center;
	padding: 0 20px;
}

.navbar__brand {
	display: flex;
	flex-direction: column;
	align-items: center;
	font-size: 20px;
	border: 2px solid teal;
	border-radius: 5px;
	padding: 3px 10px;
	cursor: pointer;
}

.navbar__btns {
	margin-left: auto;
}

</style>