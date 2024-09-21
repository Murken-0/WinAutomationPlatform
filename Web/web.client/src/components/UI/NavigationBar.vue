<template>
	<div class="navbar">
		<div
			class="navbar__brand"
			@click="$router.push('/workflows')">
			<div><strong>Платформа роботизации</strong></div>
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
  height: 60px;
  background-color: #fff;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  display: flex;
  align-items: center;
  padding: 0 20px;
}

.navbar__brand {
  display: flex;
  align-items: center;
  font-size: 25px;
  font-weight: bold;
  color: #333;
  cursor: pointer;
  user-select: none;
}

.navbar__btns {
  margin-left: auto;
}

</style>